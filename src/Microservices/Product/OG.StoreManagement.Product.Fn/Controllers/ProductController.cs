using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OG.StoreManagement.Core.DTOs;
using OG.StoreManagement.Core.Services;
using OG.StoreManagement.Product.Application.Commands;

namespace OG.StoreManagement.Product.Fn.Controllers
{

    public class ProductController(IServiceBus serviceBus, IMediator mediator, ILogger<ProductController> logger)
    {
        private readonly IServiceBus _serviceBus = serviceBus;
        private readonly ILogger<ProductController> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [Function("AddProduct")]
        public async Task<IActionResult> AddProduct([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Product/AddProduct")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ProductDTO data = JsonConvert.DeserializeObject<ProductDTO>(requestBody);

            await _mediator.Send(new AddProductCommand(data));

            _logger.LogWarning($"Product {data.Name} sended");

            return new OkResult();
        }

    }
}
