using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		private IDtoValidator<ClientDtoIn> _clientDtoValidator;
		private IAccountUnitOfWork _accountUnitOfWork;

		public AccountController(IAccountUnitOfWork accountUnitOfWork,
								 IDtoValidator<ClientDtoIn> clientDtoValidator) {
			_clientDtoValidator = clientDtoValidator;
			_accountUnitOfWork = accountUnitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> Get() {
			return Ok("Hello world");
		}

		[HttpPost("SignUp")]
		[AllowAnonymous]
		public async Task<IActionResult> SignUp(ClientDtoIn dto) {
			if (!ModelState.IsValid) {
				// Should we return ModelState from here? 
				return BadRequest(ModelState);
			}

			_clientDtoValidator.Validate(dto);
			if (_clientDtoValidator.HasError) {
				return BadRequest(_clientDtoValidator.ValidationErrors);
			}

			// TODO: Create client in database
			var client = new Client() {
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Type = dto.Type,
				Uid = "UniqueID"
			};

			var clientLogin = new ClientLogin() {
				Client = client,
				Username = dto.Username,
				Email = dto.Email,
				PasswordHash = dto.Password,    // TODO: hash the password
				PasswordSalt = "PasswordSault"  // We get this from the hash function
			};

			// This part's actually not bad
			_accountUnitOfWork.ClientRepository.Add(client);
			_accountUnitOfWork.ClientLoginRepository.Add(clientLogin);
			await _accountUnitOfWork.CompleteAsync();

			return Ok();
		}


		// Add client (anonymous sign up)
		// Login (anonymous)

		// Remove client (should be authenticated - just for same client - and admin)
		// Update client (should be authenticated - just for same client - and admin)
		// GetClient (should be authenticated - just for same client - and admin)
		// GetAListOfClients (for admin only)
		// Forgot password functionality

	}
}
