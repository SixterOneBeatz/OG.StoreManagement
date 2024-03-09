using Microsoft.Extensions.Configuration;
using OG.StoreManagement.Core.Services;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using static OG.StoreManagement.Core.Consts.QueueConsts;

namespace OG.StoreManagement.Infrastructure.Services
{
    public class RabbitServiceBus : IServiceBus
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly Dictionary<QueueEnum, string> _queueDictionary;

        public RabbitServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;

            _queueDictionary = new()
            {
                { QueueEnum.Inventory, INVENTORY_QUEUE_NAME },
                { QueueEnum.Order, ORDER_QUEUE_NAME },
                { QueueEnum.Product, PRODUCT_QUEUE_NAME },
            };

            var factory = new ConnectionFactory
            {
                Uri = new(_configuration.GetConnectionString("rabbitmq"))
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        ~RabbitServiceBus()
        {
            _connection.Dispose();
            _connection.Dispose();
        }

        public void Publish<T>(QueueEnum queue, T message)
        {
            string queueName = _queueDictionary.TryGetValue(queue, out queueName) ? queueName : string.Empty;
            string serializedMessage = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(serializedMessage);
            _channel.QueueDeclare(queueName, false, false, false, null);
            _channel.BasicPublish("", queueName, null, body);
        }
    }
}
