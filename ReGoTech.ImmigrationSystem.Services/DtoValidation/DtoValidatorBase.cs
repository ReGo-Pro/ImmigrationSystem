﻿using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public abstract class DtoValidatorBase<T> : IDtoValidator<T>
	{
		private List<DtoValidationError> ErrorList { get; set; }

		public DtoValidatorBase() {
			ErrorList = new List<DtoValidationError>();
		}

		public bool HasError => ErrorList.Any();

		public IReadOnlyList<DtoValidationError> ValidationErrors => ErrorList.AsReadOnly();

		public async Task Validate(T model) {
			await DoValidate(model);
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
