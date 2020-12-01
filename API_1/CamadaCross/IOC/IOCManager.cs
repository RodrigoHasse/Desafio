using Application.Interfaces;
using Aplicacao.Services;
using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cross.IOC
{
    public class IOCManager
    {
        public static void Register(IServiceCollection services)
        {
            // Services
            services.AddScoped<IServicoJuro, ServicoJuro>();

            //Applications Services
            services.AddScoped<IApplicationServiceJuro, AplicationServiceCalculo>();
        }
    }
}
