using Core.DTO.Order;
using Core.Entity;
using DemoTestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly OrderService _orderService;

        public OrderController(ILogger<UserController> logger, OrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<OrderEntity?> Add(AddOrderRequest request)
        {
            if(ModelState.IsValid)
            {
                _logger.Log(LogLevel.Trace, "Aboba");
                return await _orderService.Add(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<OrderEntity>?> ShowAll()
        {
            if(ModelState.IsValid)
            {
                _logger.Log(LogLevel.Trace, "Order.ShowAll");
                return await _orderService.GetAll();
            }
            return null;
        }

        [HttpPut]
        public async Task<OrderEntity?> ChangeStatus(ChangeOrderStatusRequest request)
        {
            if(ModelState.IsValid)
            {
                _logger.Log(LogLevel.Trace, "Order.ChangeStatus");
                return await _orderService.ChangeStatus(request);
            }
            return null;
        }
    }
}
