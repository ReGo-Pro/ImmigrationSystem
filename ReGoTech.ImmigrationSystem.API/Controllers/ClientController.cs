using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ReGoTech.ImmigrationSystem.Services;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	[AllowAnonymous]
	public class ClientController : ApiController
	{
		private IClientService _clientService;
		public ClientController(IClientService clientService) {
			_clientService = clientService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetAll() {
			var clients = await _clientService.GetAllClientsAsync();
			return Ok(clients.Select(x => _clientService.ConvertToDto(x)));
		}

		[HttpGet]
		[Route("{ClientId}")]
		public async Task<IActionResult> GetById(int ClientId) {
			if (ClientId <= 0) {
				return BadRequest("Invalid client ID");	// TODO: multilingual
			}

			var client = await _clientService.GetClientAsync(ClientId);
			if (client == null) {
				return NotFound();
			}

			return Ok(_clientService.ConvertToDto(client));
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> Create() {
			// Only admin use (normal clients should use sign-up endpoint)
			throw new NotImplementedException();
		}

		[HttpPut]
		[Route("{ClientId}")]
		public Task<IActionResult> Upadate(int ClientId /*, JsonPatchDocument<ClientDtoIn> dto */) {
			throw new NotImplementedException();
		}

		[HttpPatch]
		[Route("{ClientId}")]
		public Task<IActionResult> Patch(int ClientId /*, JsonPatchDocument<ClientDtoIn> dto */) {
			// Update only given client properties
			throw new NotImplementedException();
		}


		[HttpDelete]
		[Route("{ClientId}")]
		public async Task<IActionResult> Delete(int ClientId) {
			if (ClientId <= 0) {
				return BadRequest("Invalid client ID"); // TODO: multilingual
			}

			var client = await _clientService.GetClientAsync(ClientId);
			if (client == null) {
				return NotFound();
			}

			await _clientService.DeleteClient(client);

			return NoContent();
		}
	}
}
