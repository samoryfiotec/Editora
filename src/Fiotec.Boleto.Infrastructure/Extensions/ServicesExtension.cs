using Fiotec.Boletos.Infrastructure.SAP;
using Fiotec.Boletos.Infrastructure.SAP.Interface;
using Microsoft.Extensions.DependencyInjection;
using ServiceReference;

namespace Fiotec.Boletos.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesInjection(this IServiceCollection services)
        {
            services.AddTransient<ServiceSapClient>();
            services.AddTransient<ISapService, SapService>();
            return services;
        }
    }
}
