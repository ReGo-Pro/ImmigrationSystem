using ReGoTech.ImmigrationSystem.Data.EntityFramework.Repositories;
using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.WorkUnits
{
	public class UnitOfWork : IUnitOfWork
	{
		private AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext) {
			_dbContext = dbContext;
		}

		public IRepository<Client> ClientRepository => new Repository<Client>(_dbContext);

		public IRepository<ClientLogin> ClientLoginRepository => new Repository<ClientLogin>(_dbContext);

		public async Task CompleteAsync() {
			await _dbContext.SaveChangesAsync();
		}
	}
}
