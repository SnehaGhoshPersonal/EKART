using EKART.DTOs;

namespace EKART.Repositories
{
    public interface IOrderDetail
    {
        Task<string> CreateOrderDetails(OrderDetailDto orderDetailsDto);
        Task<List<OrderDetailDto>> GetAllOrderDetails();
        Task<bool> UpdateOrderDetails(int orderId,OrderDetailDto orderDetailsDto);
        Task<OrderDetailDto> GetOrderDetailByOrderId(int orderId);
    }
}
