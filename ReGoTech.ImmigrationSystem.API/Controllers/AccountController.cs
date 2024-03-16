using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		private IDtoValidator<ClientDtoIn> _clientDtoValidator;
		public AccountController(IDtoValidator<ClientDtoIn> clientDtoValidator) {
			_clientDtoValidator = clientDtoValidator;
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
