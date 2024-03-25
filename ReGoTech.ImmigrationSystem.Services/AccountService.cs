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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public class AccountService : IAccountService
	{
		private IUnitOfWork _uow;
		private ISignupModelConverter _signUpModelConverter;
		private IDtoValidator<ClientDtoIn> _dtoValidator;
		private IEmailService _emailService;

		public IReadOnlyList<DtoValidationError> DtoValidationErrors => _dtoValidator.ValidationErrors;

		public AccountService(IUnitOfWork unitOfWork,
			ISignupModelConverter modelConverter,
			IDtoValidator<ClientDtoIn> dtoValidator,
			IEmailService emailService) {
			_uow = unitOfWork;
			_signUpModelConverter = modelConverter;
			_dtoValidator = dtoValidator;
			_emailService = emailService;
		}

		public async Task<bool> IsDtoValid(ClientDtoIn dto) {
			return await _dtoValidator.IsValid(dto);
		}

		public SignUpModel ConvertToModel(ClientDtoIn dto) {
			return _signUpModelConverter.ConvertFromDto(dto);
		}

		public ClientDtoOut ConvertToDto(SignUpModel model) {
			return _signUpModelConverter.ConvertToDto(model);
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
	}
}
