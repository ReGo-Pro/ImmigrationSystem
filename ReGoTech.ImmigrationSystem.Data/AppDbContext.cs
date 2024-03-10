using Microsoft.EntityFrameworkCore;

namespace ReGoTech.ImmigrationSystem.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public AppDbContext() { }
	}
}
