using Aplicacao.Mappers.DomainToInputModel;
using AutoMapper;

namespace Aplicacao.Mappers
{
    public sealed class DomainToOutputModelMappingProfile: Profile
    {
        public DomainToOutputModelMappingProfile()
        {
            this.CalculoMap();            
        }
    }
}
