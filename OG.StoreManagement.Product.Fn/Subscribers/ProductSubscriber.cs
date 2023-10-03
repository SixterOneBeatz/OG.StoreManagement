using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace OG.StoreManagement.Product.Fn.Subscribers
{
    public class ProductSubscriber
    {
        [FunctionName("ProductSubscriber")]
        public void Run([RabbitMQTrigger("product-queue", ConnectionStringSetting = "rabbitmq")] string requestBody, ILogger log)
        {
            var data = JsonSerializer.Deserialize<Classy>(requestBody);

            log.LogWarning($"Message {data.Message} received from queue at {data.Created}");
        }
    }
}
