using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OG.StoreManagement.Core.DTOs;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OG.StoreManagement.Product.Fn.Subscribers
{
    public class ProductSubscriber(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<ProductSubscriber>();

        [Function("ProductSubscriber")]
        public void Run([RabbitMQTrigger("product-queue", ConnectionStringSetting = "rabbitmq")] string requestBody)
        {
            var data = JsonSerializer.Deserialize<ProductDTO>(requestBody);

            _logger.LogWarning($"Product {data.Name} added with {data.Price} unit price");
        }
    }
}
