using Microsoft.EntityFrameworkCore;
using ReGoTech.ImmigrationSystem.Data.EntityConfiurations;
using ReGoTech.ImmigrationSystem.Data.EntityFramework.EntityConfiurations;
using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public AppDbContext() { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfiguration(new ClientEntityConfigurations());
			modelBuilder.ApplyConfiguration(new ClientLoginEntityConfiguration());
			modelBuilder.ApplyConfiguration(new RoleEntityConfigurations());
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<ClientLogin> ClientLogins { get; set; }
		public DbSet<Role> Roles { get; set; }
	}
}
