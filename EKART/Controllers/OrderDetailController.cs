using EKART.DTOs;
using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        readonly IOrderDetail _orderDetail;
        public OrderDetailController(IOrderDetail orderDetail)
        {
            _orderDetail = orderDetail;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> CreateOrderDetails(OrderDetailDto orderDetailsDto)
        {
            return Ok(await _orderDetail.CreateOrderDetails(orderDetailsDto));
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllOrderDetailsGetAllOrderDeta()
        {
            return Ok(await _orderDetail.GetAllOrderDetails());
        }
        [HttpPut("Edit/{orderId}")]
        public async Task<ActionResult> UpdateOrderDetails(int orderId, OrderDetailDto orderDetailsDto)
        {
            bool isUpdated = await _orderDetail.UpdateOrderDetails(orderId, orderDetailsDto);

            if (isUpdated)
                return NoContent();

            return NotFound(new { message = "Customer not found or update failed." });
        }
        [HttpGet("orderId/{orderId}")]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailByOrderId(int orderId)
        {
            return Ok(await _orderDetail.GetOrderDetailByOrderId(orderId));
        }
    }
}
