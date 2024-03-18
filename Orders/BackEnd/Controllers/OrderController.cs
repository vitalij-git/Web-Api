using BackEnd.Models.Dto.Orders;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[Controller]")]
    public class OrderController : Controller
    {
      private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto){

            await _orderService.CreateOrder(orderDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder([FromHeader] int orderId)
        {
            var order = await _orderService.GetOrder(orderId);
            return Ok(order);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromHeader] int orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return Ok();    
        }

        [Route("Orders")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();   
            return Ok(orders);
        }
    }
}
