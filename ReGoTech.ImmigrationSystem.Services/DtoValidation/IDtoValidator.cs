using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public interface IDtoValidator<T>
	{
		Task Validate(T model);
		IReadOnlyList<DtoValidationError> ValidationErrors { get; }
		bool HasError { get; }
	}
}
