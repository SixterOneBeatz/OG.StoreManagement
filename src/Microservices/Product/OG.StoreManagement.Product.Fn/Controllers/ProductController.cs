using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OG.StoreManagement.Core.Services;
using static OG.StoreManagement.Core.Consts.QueueConsts;

namespace OG.StoreManagement.Product.Fn.Controllers
{

    public class ProductController(IServiceBus serviceBus, ILogger<ProductController> logger)
    {
        private readonly IServiceBus _serviceBus = serviceBus;
        private readonly ILogger<ProductController> _logger = logger;

        [Function("AddProduct")]
        public async Task<IActionResult> AddProduct([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Product/AddProduct")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ClassX data = JsonConvert.DeserializeObject<ClassX>(requestBody);
            _serviceBus.Publish(QueueEnum.Product, data);

            _logger.LogWarning($"Message {data.Message} sended at {data.Created}");

            return new OkResult();
        }

    }
}
