using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public class ClientDtoValidator : DtoValidatorBase<ClientDtoIn>
	{
		private IAccountUnitOfWork _accountUnitOfWork;
		public ClientDtoValidator(IAccountUnitOfWork accountUnitOfWork) {
			_accountUnitOfWork = accountUnitOfWork;
		}

		protected override void DoValidate(ClientDtoIn model) {
			// There are some basic validations on ClientDtoIn level (as attributes) so we skip duplicate validations here. 
			if (model.Password != model.PasswordRepeat) {
				AddError(nameof(model.PasswordRepeat), "Passwords do not match"); // TODO: support multilingual 
			}

			var existingClient = _accountUnitOfWork.ClientLoginRepository
				.FirstOrDefaultAsync(x => x.Username.ToLower() == model.Username.ToLower());
			if (existingClient != null) {
				AddError(nameof(model.Username), "Username already exists. Please choose another one.");
			}
			
			// Regex check can aslo prevent sql injection attacks
			if (!Regex.IsMatch(model.FirstName, @"^[a-zA-Z]+$")) {
				AddError(nameof(model.FirstName), "First name should only contain alphabetic characters."); // TODO: support multilingual 
			}

			if (!Regex.IsMatch(model.LastName, @"^[a-zA-Z]+$")) {
				AddError(nameof(model.LastName), "Last name should only contain alphabetic characters."); // TODO: support multilingual 
			}

			if (!Regex.IsMatch(model.Username, @"^[a-zA-Z0-9_]+$")) {
				AddError(nameof(model.Username), "Username can only contain alphanumeric and _ characters");
			}

			// TODO: Password strength validation (length, complexity, etc.)
		}
	}
}
