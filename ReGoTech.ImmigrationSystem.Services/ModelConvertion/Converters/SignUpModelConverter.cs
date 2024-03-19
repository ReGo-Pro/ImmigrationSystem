using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;

namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Converters
{
	public class SignUpModelConverter : ISignupModelConverter
	{
		public SignUpModel ConvertFromDto(ClientDtoIn dto) {
			var passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
			var hasehdPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password, passwordSalt);

			var client = new Client() {
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Type = dto.Type,
				Uid = "UniqueId"	// TODO: A service to generate unique IDs with length = 10
			};

			var clientLogin = new ClientLogin() {
				Client = client,
				Username = dto.Username,
				PasswordHash = hasehdPassword,
				PasswordSalt = passwordSalt,
				Email = dto.Email,
				IsEmailVerified = false,
				IsLockedOut = false,
				LastLoginDate = null,
				LockoutDate = null
			};

			return new SignUpModel(client, clientLogin);
		}

		public ClientDtoOut ConvertToDto(SignUpModel model) {
			return new ClientDtoOut() {
				FirstName = model.Client.FirstName,
				LastName = model.Client.LastName,
				// TODO: Find a better way for this (considering bilingual features):
				Type = Enum.GetName(model.Client.Type),     
				UniqueIdentifier = model.Client.Uid,
				Email = model.ClientLogin.Email
			};
		}
	}
}
