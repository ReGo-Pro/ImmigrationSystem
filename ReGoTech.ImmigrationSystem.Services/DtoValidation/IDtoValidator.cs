using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.ModelValidation
{
	public interface IDtoValidator<T>
	{
		List<DtoValidationError> Validate(T model);
	}
}
