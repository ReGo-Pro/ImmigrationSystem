using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts
{
    public interface IModelConverter<TModel, TDtoIn, TDtoOut>
    {
        TModel ConvertFromDto(TDtoIn dto);
        TDtoOut ConvertToDto(TModel model);
    }
}
