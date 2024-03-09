using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
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
            var data = JsonSerializer.Deserialize<ClassX>(requestBody);

            _logger.LogWarning($"Message {data.Message} received from queue at {data.Created}");
        }
    }
}
