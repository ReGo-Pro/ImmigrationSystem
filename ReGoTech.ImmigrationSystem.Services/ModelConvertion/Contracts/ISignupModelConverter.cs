using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts
{
    public interface ISignupModelConverter : IModelConverter<SignUpModel, ClientDtoIn, ClientDtoOut>
    {
    }
}
