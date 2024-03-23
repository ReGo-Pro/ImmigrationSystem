using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		private IDtoValidator<ClientDtoIn> _clientDtoValidator;
		private IUnitOfWork _uow;
		private ISignupModelConverter _signupModelConverter;

		public AccountController(IUnitOfWork accountUnitOfWork,
								 ISignupModelConverter signupModelConverter,
								 IDtoValidator<ClientDtoIn> clientDtoValidator) {
			_clientDtoValidator = clientDtoValidator;
			_uow = accountUnitOfWork;
			_signupModelConverter = signupModelConverter;
		}

		[HttpPost("SignUp")]
		[AllowAnonymous]
		public async Task<IActionResult> SignUp(ClientDtoIn dto) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			if (! await _clientDtoValidator.IsValid(dto)) {
				return BadRequest(_clientDtoValidator.ValidationErrors);
			}

			var model = _signupModelConverter.ConvertFromDto(dto);
			_uow.ClientRepository.Add(model.Client);
			_uow.ClientLoginRepository.Add(model.ClientLogin);
			await _uow.CompleteAsync();

			// TODO: Figure out what shoule be returned as URI here
			return Created("", _signupModelConverter.ConvertToDto(model));

			// Also email verification
		}

		[AllowAnonymous]
		public async Task<IActionResult> Login() {
			throw new NotImplementedException();
		}

		// Remove client (should be authenticated - just for same client - and admin)
		// Update client (should be authenticated - just for same client - and admin)
		// GetClient (should be authenticated - just for same client - and admin)
		// GetAListOfClients (for admin only)
		// Forgot password functionality

	}
}
