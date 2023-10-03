using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OG.StoreManagement.Core.Services;
using System.IO;
using System.Threading.Tasks;
using static OG.StoreManagement.Core.Consts.QueueConsts;

namespace OG.StoreManagement.Product.Fn.Controllers
{
    public class ProductController
    {
        private readonly IServiceBus _serviceBus;

        public ProductController(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        [FunctionName("AddProduct")]
        public async Task<IActionResult> AddProduct([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Product/AddProduct")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Classy data = JsonConvert.DeserializeObject<Classy>(requestBody);
            _serviceBus.Publish(QueueEnum.Product, data);

            log.LogWarning($"Message {data.Message} sended at {data.Created}");

            return new OkResult();
        }
    }
}