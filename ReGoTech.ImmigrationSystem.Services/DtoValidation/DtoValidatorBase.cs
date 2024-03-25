using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public abstract class DtoValidatorBase<T> : IDtoValidator<T>
	{
		private List<DtoValidationError> ErrorList { get; }

		public DtoValidatorBase() {
			ErrorList = new List<DtoValidationError>();
		}

		public IReadOnlyList<DtoValidationError> ValidationErrors => ErrorList.AsReadOnly();

		public async Task<bool> IsValid(T model) {
			await DoValidate(model);
			return ErrorList.Count == 0;
		}

		protected void AddError(string propertyName, string errorMessage) {
			ErrorList.Add(new DtoValidationError() { 
				PropertyName = propertyName, 
				ErrorMessage = errorMessage 
			});
		}
		protected abstract Task DoValidate(T model);

	}
}
