using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OG.StoreManagement.Core.DTOs;

namespace OG.StoreManagement.Order.Fn.Controllers
{
    public class OrderController(ILogger<OrderController> logger)
    {
        private readonly ILogger<OrderController> _logger = logger;

        [Function("GetOrder")]
        public IActionResult GetOrder([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Order/GetOrder")] HttpRequest req)
        {
            return new OkObjectResult(new OrderDTO
            {
                OrderDate = DateTime.Now,
                Status = Core.Consts.OrderConsts.OrderStatus.Pending,
                TotalAmount = 1000
            });
        }
    }
}
