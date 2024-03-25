using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using ReGoTech.ImmigrationSystem.Services;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController {
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

			if (!await _accountService.IsDtoValid(dto)) {
				return BadRequest(_accountService);
			}

			var model = _accountService.ConvertToModel(dto);
			await _accountService.AddClientAsync(model);

			// TODO: This should be coming from the request:
			var verificationEndpoint = $"https://localhost:7225/api/v1/Account/VerifyEmail?Uid={model.Client.Uid}&verificationCode={model.ClientLogin.EmailVerificationCode}";
			await _accountService.SendVerificationEmailAsync(model, verificationEndpoint);
			return Created("", _accountService.ConvertToDto(model));

			// Also email verification
		}

		[HttpGet("Login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login() {
			throw new NotImplementedException();
		}

		[HttpGet("VerifyEmail")]
		[AllowAnonymous]
		public async Task<IActionResult> VerifyEmail([FromQuery]string Uid, string verificationCode) {
			// TODO: Mark user email as verifieds
			throw new NotImplementedException(); // TODO: multilingual
		}

		// Remove client (should be authenticated - just for same client - and admin)
		// Update client (should be authenticated - just for same client - and admin)
		// GetClient (should be authenticated - just for same client - and admin)
		// GetAListOfClients (for admin only)
		// Forgot password functionality
	}
}