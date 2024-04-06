using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.EntityConfiurations
{
	internal class RolePermissionEntityConfigurations : IEntityTypeConfiguration<RolePermission>
	{
		public void Configure(EntityTypeBuilder<RolePermission> builder) {
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName(nameof(RolePermission) + "Id");

			builder.Property(x => x.RoleId).IsRequired();
			builder.Property(x => x.PermissionId).IsRequired();
			builder.Property(x => x.PermissionMask)
				.IsRequired()
				.HasMaxLength(8)
				.HasDefaultValue("00000000");
		}
	}
}
