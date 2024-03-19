using ReGoTech.ImmigrationSystem.Models.Entities;

namespace ReGoTech.ImmigrationSystem.Models.CompositeModels
{
	public class SignUpModel
	{
		public SignUpModel(Client client, ClientLogin clientLogin) {
			Client = client;
			ClientLogin = clientLogin;
		}

		public Client Client { get; init; }
		public ClientLogin ClientLogin { get; init; }
	}
}
