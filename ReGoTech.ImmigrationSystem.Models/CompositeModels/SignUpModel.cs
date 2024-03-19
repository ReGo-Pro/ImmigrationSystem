using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
