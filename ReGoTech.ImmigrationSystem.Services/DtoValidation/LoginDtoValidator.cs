using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public class LoginDtoValidator : DtoValidatorBase<LoginDtoIn>
	{
		private PasswordValidator _passwordValidator;

		public LoginDtoValidator(PasswordValidator passwordValidator) {
			_passwordValidator = passwordValidator;
		}

		protected override Task DoValidate(LoginDtoIn dto) {
			// TODO: repeated code is used. Fix it! 
			// Just for security reasons (to eliminate invalid characters from username and password)
			if (!Regex.IsMatch(dto.Username, @"^[a-zA-Z0-9_]+$")) {
				AddError(nameof(dto.Username), "Invalid username or password");		// TODO: multilingual
				return Task.CompletedTask;
			}

			if (!_passwordValidator.Validate(dto.Password)) {
				AddError(nameof(dto.Password), "Invalid username or password");		// TODO: multilingual
			}

			return Task.CompletedTask;
		}
	}
}
