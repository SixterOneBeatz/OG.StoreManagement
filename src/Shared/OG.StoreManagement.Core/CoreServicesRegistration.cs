using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OG.StoreManagement.Core
{
    public static class CoreServicesRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(assembly);
            });

            return services;
        }
    }
}
