using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound
{
	public class LoginDtoOut
	{
		public bool IsSuccessful { get; init; }
		public string AccessToken { get; init; }
        public string RefreshToken { get; set; }
        public string ErrorMessage { get; init; }
	}
}
