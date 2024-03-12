using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Core.Services;
using OG.StoreManagement.Infrastructure.Services;

namespace OG.StoreManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddGlobalInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IServiceBus, RabbitServiceBus>();
            services.AddTransient<IRestClientService, RestClientService>();

            return services;
        }
    }
}
