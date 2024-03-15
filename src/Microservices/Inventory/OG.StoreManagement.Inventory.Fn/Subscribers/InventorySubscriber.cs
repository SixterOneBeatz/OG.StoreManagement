using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Inventory.Application.Features.Events;
using System.Text.Json;

namespace OG.StoreManagement.Inventory.Fn.Subscribers
{
    public class InventorySubscriber(ILogger<InventorySubscriber> logger, IMediator mediator)
    {
        private readonly ILogger<InventorySubscriber> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [Function("InventorySubscriber")]
        public async Task Run([RabbitMQTrigger("inventory-queue", ConnectionStringSetting = "rabbitmq")] string requestBody)
        {
            var data = JsonSerializer.Deserialize<ProductDTO>(requestBody);

            await _mediator.Publish(new ProductAddedNotification(data));

            _logger.LogWarning($"Product {data.Name} added with stock {data.StockQuantity}");
        }
    }
}
