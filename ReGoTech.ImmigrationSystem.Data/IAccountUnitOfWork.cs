using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Data
{
	public interface IAccountUnitOfWork
	{
		IRepository<Client> ClientRepository { get; }
		IRepository<ClientLogin> ClientLoginRepository { get; }
		Task CompleteAsync();
	}
}
