using Microsoft.AspNetCore.Mvc;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	public class AccountController : ApiController
	{
		[HttpGet]
		public async Task<IActionResult> Get() {
			return Ok("Hello world");
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
