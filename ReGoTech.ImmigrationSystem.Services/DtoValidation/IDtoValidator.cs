using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public interface IDtoValidator<T>
	{
		Task Validate(T model);
		IReadOnlyList<DtoValidationError> ValidationErrors { get; }
		bool HasError { get; }
	}
}
