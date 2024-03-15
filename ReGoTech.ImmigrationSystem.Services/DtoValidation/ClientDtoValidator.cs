using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.ModelValidation;
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
		protected override void DoValidate(ClientDtoIn model) {
			// There are some basic validations on ClientDtoIn level (as attributes) so we skip duplicate validations here. 
			if (model.Password != model.PasswordRepeat) {
				AddError(nameof(model.PasswordRepeat), "Passwords do not match"); // TODO: support multilingual 
			}

			// TODO: Check if username exists -> This requires database access which should come from repository after it's developed
			
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
