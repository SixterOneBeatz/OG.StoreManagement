using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Core;
using OG.StoreManagement.Infrastructure;

namespace OG.StoreManagement.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGlobalServices(this IServiceCollection services)
        {
            services.AddCoreServices();
            services.AddGlobalInfrastructureServices();
            return services;
        }
    }
}
