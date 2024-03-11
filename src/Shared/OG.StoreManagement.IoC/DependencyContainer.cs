using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Infrastructure;
using static OG.StoreManagement.Product.Application.ProductApplicationServiceRegistration;

namespace OG.StoreManagement.IoC
{
    public static class DependencyContainer
    {
        public static void AddProductServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
            services.AddProductApplicationServices();
        }

        public static void AddInventoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
        }

        public static void AddOrderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
        }
    }
}
