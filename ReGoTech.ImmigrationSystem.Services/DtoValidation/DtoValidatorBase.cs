using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public void Validate(T model) {
			DoValidate(model);
		}

		protected void AddError(string propertyName, string errorMessage) {
			ErrorList.Add(new DtoValidationError() { 
				PropertyName = propertyName, 
				ErrorMessage = errorMessage 
			});
		}
		protected abstract void DoValidate(T model);

	}
}
