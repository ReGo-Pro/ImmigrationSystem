﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Data.EntityFramework.EntityConfiurations
{
	public class PermissionEntityConfigurations : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder) {
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).HasColumnName(nameof(Permission) + "Id");
			builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
		}
	}
}
