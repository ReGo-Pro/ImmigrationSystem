using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public interface IClientService 
	{
		ClientDtoOut ConvertToDto(Client client);

		Task<List<Client>> GetAllClientsAsync();
		Task<Client> GetClientAsync(int clientId);
		Task DeleteClient(Client client);
		
		// TODO: update and create
	}
}
