using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
