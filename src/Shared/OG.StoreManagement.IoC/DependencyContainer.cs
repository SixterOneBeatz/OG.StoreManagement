using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Infrastructure;
using OG.StoreManagement.Inventory.Application;
using OG.StoreManagement.Inventory.Infrastructure;
using OG.StoreManagement.Product.Application;
using OG.StoreManagement.Product.Infrastructure;

namespace OG.StoreManagement.IoC
{
    public static class DependencyContainer
    {
        public static void AddProductServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
            services.AddProductApplicationServices();
            services.AddProductInfrastructureServices(configuration);
        }

        public static void AddInventoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
            services.AddInventoryApplicationServices();
            services.AddInventoryInfrastructureServices(configuration);
        }

        public static void AddOrderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGlobalInfrastructureServices();
        }
    }
}
