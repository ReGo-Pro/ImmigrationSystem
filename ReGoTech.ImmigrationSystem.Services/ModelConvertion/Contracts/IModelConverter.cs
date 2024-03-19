
namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts
{
    public interface IModelConverter<TModel, TDtoIn, TDtoOut>
    {
        TModel ConvertFromDto(TDtoIn dto);
        TDtoOut ConvertToDto(TModel model);
    }
}
