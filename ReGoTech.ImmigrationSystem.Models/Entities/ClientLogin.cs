using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.Entities
{
	public class ClientLogin
	{
        public static int LockoutTryCount = 5;

        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
		public required string PasswordSalt { get; set; }
		public bool IsLockedOut { get; set; }
        public bool IsEmailVerified { get; set; }
        public DateTime? LockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

    }
}
