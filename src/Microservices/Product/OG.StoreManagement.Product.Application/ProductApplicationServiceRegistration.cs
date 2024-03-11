using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OG.StoreManagement.Product.Application
{
    public static class ProductApplicationServiceRegistration
    {
        public static IServiceCollection AddProductApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(assembly);
            });
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
