using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.Entities;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services
{
	public class AccountService : IAccountService
	{
		private IUnitOfWork _uow;
		private IModelConverter<SignUpModel, ClientDtoIn, ClientDtoOut> _modelConverter;
		private IDtoValidator<ClientDtoIn> _dtoValidator;

		public IReadOnlyList<DtoValidationError> DtoValidationErrors => _dtoValidator.ValidationErrors;

		public AccountService(IUnitOfWork unitOfWork,
			IModelConverter<SignUpModel, ClientDtoIn, ClientDtoOut> modelConverter,
			IDtoValidator<ClientDtoIn> dtoValidator) {
			_uow = unitOfWork;
			_modelConverter = modelConverter;
			_dtoValidator = dtoValidator;
		}

		public async Task<bool> IsDtoValid(ClientDtoIn dto) {
			return await _dtoValidator.IsValid(dto);
		}

		public SignUpModel ConvertToModel(ClientDtoIn dto) {
			return _modelConverter.ConvertFromDto(dto);
		}

		public ClientDtoOut ConvertToDto(SignUpModel model) {
			return _modelConverter.ConvertToDto(model);
		}


		public async Task AddClientAsync(SignUpModel model) {
			_uow.ClientRepository.Add(model.Client);
			_uow.ClientLoginRepository.Add(model.ClientLogin);
			await _uow.CompleteAsync();
		}
	}
}
