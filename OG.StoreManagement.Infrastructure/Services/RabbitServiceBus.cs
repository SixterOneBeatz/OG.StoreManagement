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
        private readonly Dictionary<QueueEnum, string> _queueDictionary;

        public RabbitServiceBus()
        {
            _queueDictionary = new()
            {
                { QueueEnum.Inventory, QueueNames.INVENTORY_QUEUE },
                { QueueEnum.Order, QueueNames.ORDER_QUEUE },
                { QueueEnum.Product, QueueNames.PRODUCT_QUEUE },
            };

            var factory = new ConnectionFactory
            {
                Uri = new(Environment.GetEnvironmentVariable("rabbitmq"))
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
