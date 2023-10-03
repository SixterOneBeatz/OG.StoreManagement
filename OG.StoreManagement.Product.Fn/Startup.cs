using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using OG.StoreManagement.Product.Fn;
using static OG.StoreManagement.IoC.DependencyContainer;

[assembly: FunctionsStartup(typeof(Startup))]
namespace OG.StoreManagement.Product.Fn
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddGlobalServices();
        }
    }
}
