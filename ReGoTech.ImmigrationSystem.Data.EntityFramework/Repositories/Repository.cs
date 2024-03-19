using Microsoft.EntityFrameworkCore;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System.Linq.Expressions;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
	{
		private DbContext _dbContext;

		public Repository(DbContext dbContext) {
			_dbContext = dbContext;
		}

		public async Task<TEntity> GetByIdAsync(int id) {
			return await _dbContext.FindAsync<TEntity>(id);
		}
		public async Task<List<TEntity>> GetAllAsync() {
			return await _dbContext.Set<TEntity>().ToListAsync();
		}
		public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) {
			return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
			return await _dbContext.Set<TEntity>().AnyAsync(predicate);
		}

		public void Add(TEntity entity) {
			_dbContext.Add(entity);
		}
		public void AddRange(IEnumerable<TEntity> entities) {
			_dbContext.AddRange(entities);
		}

		public void Remove(TEntity entity) {
			_dbContext.Remove(entity);
		}
		public void RemoveRange(IEnumerable<TEntity> entities) {
			_dbContext.RemoveRange(entities);
		}
	}
}
