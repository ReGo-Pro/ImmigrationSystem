﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public abstract class Person : EntityBase
	{
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
