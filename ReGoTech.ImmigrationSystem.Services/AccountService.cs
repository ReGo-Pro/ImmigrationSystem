using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public class AccountService : IAccountService {
		private IUnitOfWork _uow;
		private ISignupModelConverter _signUpModelConverter;
		private IDtoValidator<ClientDtoIn> _clientDtoValidator;
		private IDtoValidator<LoginDtoIn> _loginDtoValidator;
		private IEmailService _emailService;

		public IReadOnlyList<DtoValidationError> DtoValidationErrors {
			get {
				return _clientDtoValidator.ValidationErrors
					.Union(_loginDtoValidator.ValidationErrors).ToList();
			}
		}

		public AccountService(IUnitOfWork unitOfWork,
			ISignupModelConverter modelConverter,
			IDtoValidator<ClientDtoIn> clientDtoValidator,
			IDtoValidator<LoginDtoIn> loginDtoValidator,
			IEmailService emailService) {
			_uow = unitOfWork;
			_signUpModelConverter = modelConverter;
			_clientDtoValidator = clientDtoValidator;
			_emailService = emailService;
			_loginDtoValidator = loginDtoValidator;
		}

		public async Task<bool> IsClientDtoValid(ClientDtoIn dto) {
			return await _clientDtoValidator.IsValid(dto);
		}

		public SignUpModel ConvertToModel(ClientDtoIn dto) {
			return _signUpModelConverter.ConvertFromDto(dto);
		}

		public ClientDtoOut ConvertToDto(SignUpModel model) {
			return _signUpModelConverter.ConvertToDto(model);
		}

		public async Task<bool> IsLoginDtoValid(LoginDtoIn dto) {
			return await _loginDtoValidator.IsValid(dto);
		}

		public async Task AddClientAsync(SignUpModel model) {
			model.ClientLogin.EmailVerificationCode = Guid.NewGuid().ToString("N");
			model.ClientLogin.LastVerificationSentTime = DateTime.Now;
			_uow.ClientRepository.Add(model.Client);
			_uow.ClientLoginRepository.Add(model.ClientLogin);
			await _uow.CompleteAsync();
		}

		public async Task SendVerificationEmailAsync(SignUpModel model, string verificationUrl) {
			var subject = "Please verify your email"; // TODO: multilingual
			var body = @$"
<h5>Dear {model.Client.FirstName}<h5>,

<pre>Thank you for registering with our platform. To activate your account, please click on the link below:
<a href='{verificationUrl}'>Verify my email address</a>
Please note that this link will expire in 1 hour.</p>
If you did not sign up for an account with us, please ignore this email.

Yours sincerely,
ReGoTech.net Team</pre>
";  // TODO: multilingual - Move to database

			// TODO: This method needs reviewing
			int retryCount = 0;
			while (true) {
				try {
					if (retryCount == 3) {
						// return a message letting use know that the email could not be sent
						break;
					}

					await _emailService.SendAsync(model.ClientLogin.Email, subject, body);
					break;
				}
				catch (Exception) {
					// log error
					// update database with retry count
					retryCount++;
				}
			}
		}

		public async Task<bool> VerifyClientEmail(string UID, string verificationCode) {
			var client = await _uow.ClientRepository.SingleOrDefaultAsync(x => x.Uid == UID);
			if (client.ClientLogin.EmailVerificationCode == verificationCode && !IsVerificationCodeExpired(client.ClientLogin)) {
				client.ClientLogin.IsEmailVerified = true;
				await _uow.CompleteAsync();
				return true;
			}
			else {
				return false;
			}
		}

		public async Task<LoginDtoOut> LoginClientAsync(LoginDtoIn dto) {
			var userLogin = await _uow.ClientLoginRepository.SingleOrDefaultAsync(x => x.Username == dto.Username);
			// userLogin shouldn't be null
			if (userLogin != null && BCrypt.Net.BCrypt.Verify(dto.Password, userLogin.PasswordHash)) {
				return new LoginDtoOut() {
					IsSuccessful = true,
					Token = GenerateJWTToken(userLogin.Username)
				};
			}

			return new LoginDtoOut() {
				IsSuccessful = false,
				ErrorMessage = "Invalid username or password"	// TODO: bilingual
			};
		}

		private string GenerateJWTToken(string username) {
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ReGoTech.net-ReGoTech.net-ReGoTech.net-ReGoTech.net-ReGoTech.net"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, username),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
				issuer: "https://localhost:7225", 
				audience: "https://localhost:7225", 
				claims: claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private bool IsVerificationCodeExpired(ClientLogin login) {
			return DateTime.Now - login.LastVerificationSentTime > TimeSpan.FromMinutes(60);
		}
	}
}