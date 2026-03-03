using EKART.DTOs;
using EKART.Models;

namespace EKART.Repositories
{
    public interface IOrder
    {
        Task<bool> CreateOrder(OrderDto order);
        Task<List<OrderDto>> GetAllOrders();
        Task<bool> UpdateOrderByOrderId(int orderId, OrderDto order);
        Task<bool> UpdateOrderByCustomerId(int customerId, OrderDto order);
        Task<List<OrderDto>> GetOrdersByCustomer(int customer);
        Task<List<OrderDto>> GetOrdersOnSpecificDate(DateTime orderDate);
        Task<List<OrderDto>> GetOrdersBetweenTwoDates(DateTime startingDate, DateTime endingDate);
        Task<List<int>> GetHighestOrderCustomer();
    }
}
