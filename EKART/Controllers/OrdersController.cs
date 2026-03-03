using EKART.DTOs;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _order;
        public OrdersController(IOrder order)
        {
            _order = order;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> CreateOrder(OrderDto orderDto)
        {
            return Ok(await _order.CreateOrder(orderDto));
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllOrders()
        {
            return Ok(await _order.GetAllOrders());
        }
        [HttpPut("Edit/{customerId}/{order}")]
        public async Task<ActionResult> UpdateOrderByCustomerId(int customerId, OrderDto order)
        {
            bool isUpdated = await _order.UpdateOrderByCustomerId(customerId, order);

            if (isUpdated)
                return NoContent();

            return NotFound(new { message = "Customer not found or update failed." });

        }
        [HttpGet("customerId/{customerId}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersByCustomer(int customerId)
        {
            return await _order.GetOrdersByCustomer(customerId);
        }
        [HttpGet("orderDate/{orderDate}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersOnSpecificDate(DateTime orderDate)
        {
            return await _order.GetOrdersOnSpecificDate(orderDate);
        }
        [HttpGet("orderDate/{startingDate}/{endingDate}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersBetweenTwoDates(DateTime startingDate, DateTime endingDate)
        {
            return await _order.GetOrdersBetweenTwoDates(startingDate, endingDate);
        }
        [HttpGet("HigestOrderCustomer")]
        public async Task<ActionResult<List<int>>> GetHighestOrderCustomer()
        {
            return await _order.GetHighestOrderCustomer();
        }
    }
}
