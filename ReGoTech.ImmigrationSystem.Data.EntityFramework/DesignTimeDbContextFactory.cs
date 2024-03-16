using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ReGoTech.ImmigrationSystem.Data
{
	internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args) {
			var designDbConnex = "Server=REGO\\SQLEXPRESS;Database=ImmigrationMaster;User Id=sa;Password=R_123456;Encrypt=True;TrustServerCertificate=True;";
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlServer(designDbConnex);
			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
