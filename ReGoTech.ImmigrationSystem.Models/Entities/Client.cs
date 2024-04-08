using ReGoTech.ImmigrationSystem.Common;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class Client : Person
	{
        public required string Uid { get; set; }
        public ClientType Type { get; set; }

        public virtual ClientLogin? ClientLogin { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
