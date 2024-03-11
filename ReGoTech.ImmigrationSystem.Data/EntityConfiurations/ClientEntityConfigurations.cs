using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data.EntityConfiurations
{
	internal class ClientEntityConfigurations : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder) {
			builder.ToTable("Clients");		// Use TPT for inheritance
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).HasColumnName("ClientId");
			builder.Property(x => x.FirstName).HasMaxLength(128);
			builder.Property(x => x.LastName).HasMaxLength(128);
			builder.Property(x => x.Uid).HasMaxLength(10);
		}
	}
}
