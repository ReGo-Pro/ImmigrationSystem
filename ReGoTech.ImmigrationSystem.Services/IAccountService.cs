using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public interface IAccountService
	{
		Task<bool> IsDtoValid(ClientDtoIn dto);
		SignUpModel ConvertToModel(ClientDtoIn dto);
		ClientDtoOut ConvertToDto(SignUpModel model);
		IReadOnlyList<DtoValidationError> DtoValidationErrors { get; }

		Task AddClientAsync(SignUpModel model);
	}
}
