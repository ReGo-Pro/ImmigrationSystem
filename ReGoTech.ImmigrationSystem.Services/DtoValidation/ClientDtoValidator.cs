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
		private IUnitOfWork _accountUnitOfWork;
		private PasswordValidator _passwordValidator;
		public ClientDtoValidator(IUnitOfWork accountUnitOfWork, PasswordValidator passwordValidator) {
			_accountUnitOfWork = accountUnitOfWork;
			_passwordValidator = passwordValidator;
		}

		protected override async Task DoValidate(ClientDtoIn dto) {
			// There are some basic validations on ClientDtoIn level (as attributes) so we skip duplicate validations here. 
			if (dto.Password != dto.PasswordRepeat) {
				AddError(nameof(dto.PasswordRepeat), "Passwords do not match"); // TODO: support multilingual 
			}

			var usernameExists = await _accountUnitOfWork.ClientLoginRepository
				.AnyAsync(x => x.Username == dto.Username);
			if (usernameExists) {
				AddError(nameof(dto.Username), "Username already exists. Please choose another one.");
			}
			
			// Regex check can aslo prevent sql injection attacks
			if (!Regex.IsMatch(dto.FirstName, @"^[a-zA-Z]+$")) {
				AddError(nameof(dto.FirstName), "First name should only contain alphabetic characters."); // TODO: support multilingual 
			}

			if (!Regex.IsMatch(dto.LastName, @"^[a-zA-Z]+$")) {
				AddError(nameof(dto.LastName), "Last name should only contain alphabetic characters."); // TODO: support multilingual 
			}

			if (!Regex.IsMatch(dto.Username, @"^[a-zA-Z0-9_]+$")) {
				AddError(nameof(dto.Username), "Username can only contain alphanumeric and _ characters");
			}

			if (!_passwordValidator.Validate(dto.Password)) {
				AddError(nameof(dto.Password), _passwordValidator.ErrorMessage);
			}
		}
	}
}
