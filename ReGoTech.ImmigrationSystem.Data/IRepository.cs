using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Data
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<TEntity> GetByIdAsync(int id);
		Task<List<TEntity>> GetAllAsync(Func<TEntity, bool> predicate);
		Task<List<TEntity>> GetAllAsync();

		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
