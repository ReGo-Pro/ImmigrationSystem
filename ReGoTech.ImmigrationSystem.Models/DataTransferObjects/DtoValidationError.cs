using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Models.DataTransferObjects
{
	public class DtoValidationError
	{
        public required string PropertyName { get; set; }
		public required string ErrorMessage { get; set; }
    }
}
