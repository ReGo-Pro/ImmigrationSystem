using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;

namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts
{
    public interface ISignupModelConverter : IModelConverter<SignUpModel, ClientDtoIn, ClientDtoOut>
    {
    }
}
