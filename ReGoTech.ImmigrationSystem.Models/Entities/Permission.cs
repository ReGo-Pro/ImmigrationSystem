using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class Permission : EntityBase
	{
        public required string Name { get; set; }
        public required string Mask { get; set; }
        public required string Description { get; set; }
    }
}
