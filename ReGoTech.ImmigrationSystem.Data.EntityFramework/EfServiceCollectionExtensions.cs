using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework
{
	public static class EfServiceCollectionExtensions
	{
		public static void AddEFWithSqlServer(this IServiceCollection services, string connectionString) {
			services.AddDbContext<AppDbContext>(o => {
				o.UseLazyLoadingProxies();
				o.UseSqlServer(connectionString);
			});
		}
	}
}
