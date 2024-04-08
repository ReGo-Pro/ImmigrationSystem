using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class RolePermission : EntityBase
	{
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public string PermissionMask { get; set; }  // CRUD----
    }
}
