using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Client> ClientRepository { get; }
		IRepository<ClientLogin> ClientLoginRepository { get; }
		Task CompleteAsync();
	}
}
