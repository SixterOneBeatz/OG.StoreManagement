using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Inventory.Application.Common.Interfaces;
using OG.StoreManagement.Inventory.Infrastructure.Implementations;
using System.Data;
using System.Data.SqlClient;

namespace OG.StoreManagement.Inventory.Infrastructure
{
    public static class InventoryInfrastructureServiceRegistration
    {
        public static void AddInventoryInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("InventoryDB")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
