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
        public string Uid { get; set; }
        public ClientType Type { get; set; }
    }
}
