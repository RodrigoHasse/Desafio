using Core.Models.Calculo;
using Core.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Mappers.DomainToInputModel
{
    public static class CalculoMappingOut
    {
        public static void CalculoMap(this DomainToOutputModelMappingProfile profile)
        {
            profile.CreateMap<Calculo, CalculoOutputModel>();
        }
    }
}
