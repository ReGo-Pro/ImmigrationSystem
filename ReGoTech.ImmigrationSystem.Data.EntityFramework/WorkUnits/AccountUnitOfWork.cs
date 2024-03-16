using Microsoft.EntityFrameworkCore;
using ReGoTech.ImmigrationSystem.Data.EntityFramework.Repositories;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.WorkUnits
{
	public class AccountUnitOfWork : IAccountUnitOfWork
	{
		private AppDbContext _dbContext;

		public AccountUnitOfWork(AppDbContext dbContext) {
			_dbContext = dbContext;
		}

		public IRepository<Client> ClientRepository => new Repository<Client>(_dbContext);

		public IRepository<ClientLogin> ClientLoginRepository => new Repository<ClientLogin>(_dbContext);

		public async Task CompleteAsync() {
			await _dbContext.SaveChangesAsync();
		}
	}
}
