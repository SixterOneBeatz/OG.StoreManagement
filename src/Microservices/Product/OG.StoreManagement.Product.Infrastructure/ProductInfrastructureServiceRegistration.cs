using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Product.Application.Common.Interfaces;
using OG.StoreManagement.Product.Infrastructure.Implementations;
using System.Data;
using System.Data.SqlClient;

namespace OG.StoreManagement.Product.Infrastructure
{
    public static class ProductInfrastructureServiceRegistration
    {
        public static void AddProductInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("ProductDB")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
