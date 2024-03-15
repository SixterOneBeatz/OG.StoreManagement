using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OG.StoreManagement.Inventory.Application
{
    public static class InventoryApplicationServiceRegistration
    {
        public static void AddInventoryApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(assembly);
            });
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
