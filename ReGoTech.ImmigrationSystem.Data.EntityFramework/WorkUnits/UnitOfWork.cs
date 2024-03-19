using ReGoTech.ImmigrationSystem.Data.EntityFramework.Repositories;
using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.WorkUnits
{
	public class UnitOfWork : IUnitOfWork
	{
		private AppDbContext _dbContext;
		private IRepository<Client> _clientRepository;
		private IRepository<ClientLogin> _clientLoginRepository;

		public UnitOfWork(AppDbContext dbContext) {
			_dbContext = dbContext;
		}

		// Use lazy initialization
		public IRepository<Client> ClientRepository => _clientRepository ?? new Repository<Client>(_dbContext);
		public IRepository<ClientLogin> ClientLoginRepository => _clientLoginRepository ?? new Repository<ClientLogin>(_dbContext);

		public async Task CompleteAsync() {
			await _dbContext.SaveChangesAsync();
		}

		public void Dispose() {
			_dbContext.Dispose();
		}
	}
}
