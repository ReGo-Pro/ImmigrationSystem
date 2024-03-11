using ReGoTech.ImmigrationSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class Client : Person
	{
        public required string Uid { get; set; }
        public ClientType Type { get; set; }

        public virtual ClientLogin? ClientLogin { get; set; }
    }
}
