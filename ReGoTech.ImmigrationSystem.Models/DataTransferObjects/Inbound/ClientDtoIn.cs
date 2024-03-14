using ReGoTech.ImmigrationSystem.Constants;
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
        [StringLength(255)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public required string LastName { get; set; }

        [Required]
        [Range(1,2)]
        public ClientType Type { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength (255)]
        public string PasswordRepeat { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
