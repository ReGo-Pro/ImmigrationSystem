using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public class ClientService : IClientService
	{
		private IUnitOfWork _uow;
		public ClientService(IUnitOfWork unitOfWork) {
			_uow = unitOfWork;
		}

		public ClientDtoOut ConvertToDto(Client client) {
			return new ClientDtoOut() {
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.ClientLogin.Email,
				Type = client.Type.ToString(),

				UniqueIdentifier = client.Uid
			};
		}

		public async Task DeleteClient(Client client) {
			_uow.ClientRepository.Remove(client);
			await _uow.CompleteAsync();
		}

		public async Task<List<Client>> GetAllClientsAsync() {
			return await _uow.ClientRepository.GetAllAsync();
		}

		public async Task<Client> GetClientAsync(int clientId) {
			return await _uow.ClientRepository.GetByIdAsync(clientId);
		}
	}
}
