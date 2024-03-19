
namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public abstract class Person : EntityBase
	{
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
