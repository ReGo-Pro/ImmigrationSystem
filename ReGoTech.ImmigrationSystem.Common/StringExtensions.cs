using System.Text.RegularExpressions;

namespace ReGoTech.ImmigrationSystem.Common
{
	public static class StringExtensions
	{

		public static bool ContainsNumbers(this string str) {
			return (Regex.IsMatch(str, @"[0-9]"));
		}

		public static bool ContainsLowerCaseLetters(this string str) {
			return (Regex.IsMatch(str, @"[a-z]"));
		}

		public static bool ContainsUpperCaseLetters(this string str) {
			return (Regex.IsMatch(str, @"[A-Z]"));
		}

		public static bool ContainsSpecialCharacters(this string str) {
			return Regex.IsMatch(str, "[@$%^#&*()_+=!-]");
		}
	}
}
