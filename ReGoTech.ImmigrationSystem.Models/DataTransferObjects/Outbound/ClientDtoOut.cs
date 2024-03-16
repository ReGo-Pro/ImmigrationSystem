using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound
{
	public class ClientDtoOut : OutboundDtoBase
	{
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Type { get; set; }
        public required string UniqueIdentifier { get; set; }
        public required string Email { get; set; }
    }
}
