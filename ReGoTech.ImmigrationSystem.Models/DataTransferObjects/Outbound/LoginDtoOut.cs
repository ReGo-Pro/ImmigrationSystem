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
		public string Token { get; init; }
		public string ErrorMessage { get; init; }
	}
}
