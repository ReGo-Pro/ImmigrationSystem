using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Data.EntityConfiurations
{
	internal class ClientLoginEntityConfiguration : IEntityTypeConfiguration<ClientLogin>
	{
		public void Configure(EntityTypeBuilder<ClientLogin> builder) {
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).HasColumnName(nameof(ClientLogin) + "Id");
			builder.Property(x => x.Username).IsRequired().HasMaxLength(32);
			builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(256);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
			builder.Property(x => x.IsEmailVerified).IsRequired();
			builder.Property(x => x.IsLockedOut).IsRequired();
			builder.Property(x => x.EmailVerificationCode).IsRequired().HasMaxLength(32);
			builder.Property(x => x.RefreshToken).HasMaxLength(64);
		}
	}
}
