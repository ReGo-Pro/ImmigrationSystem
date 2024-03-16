using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		private IDtoValidator<ClientDtoIn> _clientDtoValidator;
		private IAccountUnitOfWork _accountUnitOfWork;
		private ISignupModelConverter _signupModelConverter;

		public AccountController(IAccountUnitOfWork accountUnitOfWork,
								 ISignupModelConverter signupModelConverter,
								 IDtoValidator<ClientDtoIn> clientDtoValidator) {
			_clientDtoValidator = clientDtoValidator;
			_accountUnitOfWork = accountUnitOfWork;
			_signupModelConverter = signupModelConverter;
		}

		[HttpGet]
		public async Task<IActionResult> Get() {
			return Ok("Hello world");
		}

		[HttpPost("SignUp")]
		[AllowAnonymous]
		public async Task<IActionResult> SignUp(ClientDtoIn dto) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			_clientDtoValidator.Validate(dto);
			if (_clientDtoValidator.HasError) {
				return BadRequest(_clientDtoValidator.ValidationErrors);
			}

			var model = _signupModelConverter.ConvertFromDto(dto);
			_accountUnitOfWork.ClientRepository.Add(model.Client);
			_accountUnitOfWork.ClientLoginRepository.Add(model.ClientLogin);
			await _accountUnitOfWork.CompleteAsync();

			// TODO: Figure out what shoule be returned as URI here
			return Created("", _signupModelConverter.ConvertToDto(model));
		}

		// Login (anonymous)

		// Remove client (should be authenticated - just for same client - and admin)
		// Update client (should be authenticated - just for same client - and admin)
		// GetClient (should be authenticated - just for same client - and admin)
		// GetAListOfClients (for admin only)
		// Forgot password functionality

	}
}
