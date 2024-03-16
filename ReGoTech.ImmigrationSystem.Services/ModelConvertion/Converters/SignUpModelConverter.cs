using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Models.MixedModels;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Converters
{
	public class SignUpModelConverter : ISignupModelConverter
	{
		public SignUpModel ConvertFromDto(ClientDtoIn dto) {
			var client = new Client() {
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Type = dto.Type,
				Uid = "UniqueId"
			};

			var clientLogin = new ClientLogin() {
				Client = client,
				Username = dto.Username,
				PasswordHash = dto.Password,        // TODO: Hash the password
				PasswordSalt = "PasswordSalt",      // TODO: Get from hash function
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
