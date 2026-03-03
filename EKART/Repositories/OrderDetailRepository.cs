using EKART.DTOs;
using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repositories
{
    public class OrderDetailRepository:IOrderDetail
    {
        readonly EKARTContext _context;
        public OrderDetailRepository(EKARTContext context)
        {
            _context = context;
        }
        public async Task<string> CreateOrderDetails(OrderDetailDto orderDetailsDto)
        {
            var orderDetails = new OrderDetail()
            {
                OrderId = orderDetailsDto.OrderId,
                ProductId = orderDetailsDto.ProductId,
                UnitPrice = orderDetailsDto.UnitPrice,
                Quantity = orderDetailsDto.Quantity,
                Discount = orderDetailsDto.Discount
            };
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
            return "Order Details added successfully";
        }
        public async Task<List<OrderDetailDto>> GetAllOrderDetails()
        {
            try
            {
                var orderDetailsDto = new List<OrderDetailDto>();
                var orderDetails = await _context.OrderDetails.ToListAsync();
                foreach (var orderDetail in orderDetails)
                {
                    var orderDetailDto = new OrderDetailDto()
                    {
                        OrderId = orderDetail.OrderId,
                        ProductId = orderDetail.ProductId,
                        UnitPrice = orderDetail.UnitPrice,
                        Quantity = orderDetail.Quantity,
                        Discount = orderDetail.Discount
                    };
                    orderDetailsDto.Add(orderDetailDto);
                }
                return orderDetailsDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OrderDetailDto>();
            }
        }
        public async Task<bool> UpdateOrderDetails(int orderId,OrderDetailDto orderDetailsDto)
        {
            try 
            {
                var toUpdate = await _context.OrderDetails.FirstOrDefaultAsync(o => o.OrderId == orderId);
                if (toUpdate != null)
                {
                    toUpdate.ProductId = orderDetailsDto.ProductId;
                    toUpdate.UnitPrice = orderDetailsDto.UnitPrice;
                    toUpdate.Quantity = orderDetailsDto.Quantity;
                    toUpdate.Discount = orderDetailsDto.Discount;
                    return true;
                }
                else
                {
                    Console.WriteLine("Customer not found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<OrderDetailDto> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (orderDetail == null)
                throw new NotFoundException("Not Found the order with given orderID");
            else {
                var orderDetailDto = new OrderDetailDto
                {
                    OrderId = orderId,
                    ProductId = orderDetail.ProductId,
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity,
                    Discount = orderDetail.Discount
                };
                return orderDetailDto;
            }
        
            
        }
    }
}
