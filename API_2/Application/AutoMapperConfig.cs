using Aplicacao.Mappers;
using AutoMapper;
using System;

namespace Aplicacao
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static MapperConfiguration RegisterMappings(IServiceProvider serviceProvider)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToOutputModelMappingProfile());                
            });

            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
