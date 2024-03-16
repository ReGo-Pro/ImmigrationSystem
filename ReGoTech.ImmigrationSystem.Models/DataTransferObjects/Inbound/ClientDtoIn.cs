using ReGoTech.ImmigrationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound
{
	public class ClientDtoIn : InboundDtoBase
	{
        [Required]
        [StringLength(128)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public required string LastName { get; set; }

        [Required]
        [Range(1,2)]
        public ClientType Type { get; set; }

        [Required]
        [StringLength(32)]
        public required string Username { get; set; }

        [Required]
        [StringLength(32)]
        public required string Password { get; set; }

        [Required]
        [StringLength (32)]
        public required string PasswordRepeat { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(128)]
        public required string Email { get; set; }
    }
}
