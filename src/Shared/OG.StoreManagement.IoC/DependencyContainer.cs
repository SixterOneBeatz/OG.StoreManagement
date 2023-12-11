using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OG.StoreManagement.Core.Services;
using OG.StoreManagement.Infrastructure.Services;

namespace OG.StoreManagement.IoC
{
    public static class DependencyContainer
    {
        public static void AddGlobalServices(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IServiceBus, RabbitServiceBus>();
        }
    }
}
