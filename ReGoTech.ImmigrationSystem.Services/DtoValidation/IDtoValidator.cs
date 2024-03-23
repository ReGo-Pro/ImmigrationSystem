using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public interface IDtoValidator<T>
	{
		Task<bool> IsValid(T model);
		IReadOnlyList<DtoValidationError> ValidationErrors { get; }
	}
}
