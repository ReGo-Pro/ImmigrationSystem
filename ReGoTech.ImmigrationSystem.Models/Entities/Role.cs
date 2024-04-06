﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class Role : EntityBase
	{
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
