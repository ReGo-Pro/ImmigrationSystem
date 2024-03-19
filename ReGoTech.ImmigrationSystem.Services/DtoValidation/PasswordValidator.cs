using ReGoTech.ImmigrationSystem.Common;
using System.Text;

namespace ReGoTech.ImmigrationSystem.Services.DtoValidation
{
	public class PasswordValidator
	{
		private int _minLength = 8;
		private bool _shouldContainSpecialCharacters;
		private bool _shouldContaintNumbers;
		private bool _shouldContainLowerCaseLetters;
		private bool _shouldContainUpperCaseLetters;
		private StringBuilder _errorMessageBuilder = new ("Password is not strong enough. Please consider the following:");

        public string? ErrorMessage => _errorMessageBuilder.ToString();

		public PasswordValidator HasMinLength(int minLength) {
			_minLength = minLength;
			return this;
		}

		public PasswordValidator ShouldContainSpecialCharacters() {
			_shouldContainSpecialCharacters = true;
			return this;
		}

		public PasswordValidator ShouldContainNumbers() {
			_shouldContaintNumbers = true;
			return this;
		}

		public PasswordValidator ShouldContainLowerCaseLetters() {
			_shouldContainLowerCaseLetters = true;
			return this;
		}

		public PasswordValidator ShouldContainUpperCaseLetters() {
			_shouldContainUpperCaseLetters = true;
			return this;
		}

		public bool Validate(string password) {
			var isValid = true;

			if (_shouldContainLowerCaseLetters) {
				if (!password.ContainsLowerCaseLetters()) {
					isValid = false;
					_errorMessageBuilder.AppendLine(" - Use at least one lowercase letter");
				}
			}

			if (_shouldContainUpperCaseLetters) {
				if (!password.ContainsUpperCaseLetters()) {
					isValid = false;
					_errorMessageBuilder.AppendLine(" - Use at least one uppercase letter");
				}
			}

			if (_shouldContaintNumbers) {
				if (!password.ContainsNumbers()) { 
					isValid = false;
					_errorMessageBuilder.AppendLine(" _ Use at least one number");
				}
			}

			if (_shouldContainSpecialCharacters) {
				if (!password.ContainsSpecialCharacters()) {
					_errorMessageBuilder.AppendLine(" _ Use at least one of the following characters: @$%^#&*()_+=!-");
				}
			}

			return isValid;
		}
	}
}
