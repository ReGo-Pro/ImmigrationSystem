using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using ReGoTech.ImmigrationSystem.Services;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		IAccountService _accountService;

		public AccountController(IAccountService accountService) {
			_accountService = accountService;
		}

		[HttpPost("SignUp")]
		[AllowAnonymous]
		public async Task<IActionResult> SignUp(ClientDtoIn dto) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			if (! await _accountService.IsDtoValid(dto)) {
				return BadRequest(_accountService);
			}

			var model = _accountService.ConvertToModel(dto);
			await _accountService.AddClientAsync(model);

			return Created("", _accountService.ConvertToDto(model));

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
