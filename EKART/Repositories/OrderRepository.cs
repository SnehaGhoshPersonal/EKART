using System.Net;
using EKART.DTOs;
using EKART.Models;
using Microsoft.EntityFrameworkCore;

namespace EKART.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly EKARTContext _context;

        public OrderRepository(EKARTContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateOrder(OrderDto orderDto)
        {
            try
            {
                Order order = new Order
                {
                    CustomerId = orderDto.CustomerId,
                    EmployeeId = orderDto.EmployeeId,
                    OrderDate = orderDto.OrderDate,
                    RequiredDate = orderDto.RequiredDate,
                    ShippedDate = orderDto.ShippedDate,
                    ShipVia = orderDto.ShipVia,
                    Freight = orderDto.Freight,
                    ShipName = orderDto.ShipName,
                    ShipAddress = orderDto.ShipAddress,
                    ShipCity = orderDto.ShipCity,
                    ShipRegion = orderDto.ShipRegion,
                    ShipPostalCode = orderDto.ShipPostalCode,
                    ShipCountry = orderDto.ShipCountry
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<List<OrderDto>> GetAllOrders()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                List<OrderDto> ordersDto = new List<OrderDto>();
                foreach (var order in orders)
                {
                    var orderDto = new OrderDto
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        EmployeeId = order.EmployeeId,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    };
                    ordersDto.Add(orderDto);
                }
                return ordersDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OrderDto> { new OrderDto() };
            }
        }
        public async Task<bool> UpdateOrderByOrderId(int orderId, OrderDto order)
        {
            try
            {
                var toUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
                if (toUpdate == null) return false;
                var toUpdateDto = new OrderDto
                {
                    OrderId = orderId,
                    CustomerId = toUpdate.CustomerId,
                    EmployeeId = toUpdate.EmployeeId,
                    OrderDate = toUpdate.OrderDate,
                    RequiredDate = toUpdate.RequiredDate,
                    ShippedDate = toUpdate.ShippedDate,
                    ShipVia = toUpdate.ShipVia,
                    Freight = toUpdate.Freight,
                    ShipName = toUpdate.ShipName,
                    ShipAddress = toUpdate.ShipAddress,
                    ShipCity = toUpdate.ShipCity,
                    ShipRegion = toUpdate.ShipRegion,
                    ShipPostalCode = toUpdate.ShipPostalCode,
                    ShipCountry = toUpdate.ShipCountry
                };
                toUpdate.OrderId = toUpdateDto.OrderId;
                toUpdate.CustomerId = toUpdateDto.CustomerId;
                toUpdate.EmployeeId = toUpdateDto.EmployeeId;
                toUpdate.OrderDate = toUpdateDto.OrderDate;
                toUpdate.OrderDate = toUpdateDto.OrderDate;
                toUpdate.RequiredDate = toUpdateDto.RequiredDate;
                toUpdate.ShippedDate = toUpdateDto.ShippedDate;
                toUpdate.ShipVia = toUpdateDto.ShipVia;
                toUpdate.Freight = toUpdateDto.Freight;
                toUpdate.ShipName = toUpdateDto.ShipName;
                toUpdate.ShipAddress = toUpdateDto.ShipAddress;
                toUpdate.ShipCity = toUpdateDto.ShipCity;
                toUpdate.ShipRegion = toUpdateDto.ShipRegion;
                toUpdate.ShipPostalCode = toUpdateDto.ShipPostalCode;
                toUpdate.ShipCountry = toUpdateDto.ShipCountry;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateOrderByCustomerId(int customerId, OrderDto order)
        {
            try
            {
                var toUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.CustomerId == customerId);
                if (toUpdate == null) return false;
                var toUpdateDto = new OrderDto
                {
                    OrderId = toUpdate.OrderId,
                    CustomerId = customerId,
                    EmployeeId = toUpdate.EmployeeId,
                    OrderDate = toUpdate.OrderDate,
                    RequiredDate = toUpdate.RequiredDate,
                    ShippedDate = toUpdate.ShippedDate,
                    ShipVia = toUpdate.ShipVia,
                    Freight = toUpdate.Freight,
                    ShipName = toUpdate.ShipName,
                    ShipAddress = toUpdate.ShipAddress,
                    ShipCity = toUpdate.ShipCity,
                    ShipRegion = toUpdate.ShipRegion,
                    ShipPostalCode = toUpdate.ShipPostalCode,
                    ShipCountry = toUpdate.ShipCountry
                };
                toUpdate.OrderId = toUpdateDto.OrderId;
                toUpdate.CustomerId = toUpdateDto.CustomerId;
                toUpdate.EmployeeId = toUpdateDto.EmployeeId;
                toUpdate.OrderDate = toUpdateDto.OrderDate;
                toUpdate.OrderDate = toUpdateDto.OrderDate;
                toUpdate.RequiredDate = toUpdateDto.RequiredDate;
                toUpdate.ShippedDate = toUpdateDto.ShippedDate;
                toUpdate.ShipVia = toUpdateDto.ShipVia;
                toUpdate.Freight = toUpdateDto.Freight;
                toUpdate.ShipName = toUpdateDto.ShipName;
                toUpdate.ShipAddress = toUpdateDto.ShipAddress;
                toUpdate.ShipCity = toUpdateDto.ShipCity;
                toUpdate.ShipRegion = toUpdateDto.ShipRegion;
                toUpdate.ShipPostalCode = toUpdateDto.ShipPostalCode;
                toUpdate.ShipCountry = toUpdateDto.ShipCountry;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<List<OrderDto>> GetOrdersByCustomer(int customerId)
        {
            try
            {
                var orders = await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
                var orderDtos = new List<OrderDto>();
                foreach (var order in orders)
                {
                    var orderDto = new OrderDto
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        EmployeeId = order.EmployeeId,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    };
                    orderDtos.Add(orderDto);
                }
                return orderDtos;
            }
        
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OrderDto> { new OrderDto() };
            }
        }
        public async Task<List<OrderDto>> GetOrdersOnSpecificDate(DateTime orderDate)
        {
            try
            {
                var orders = await _context.Orders.Where(o => o.OrderDate == orderDate).ToListAsync();
                var orderDtos = new List<OrderDto>();
                foreach (var order in orders)
                {
                    var orderDto = new OrderDto
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        EmployeeId = order.EmployeeId,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    };
                    orderDtos.Add(orderDto);
                }
                return orderDtos;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OrderDto> { new OrderDto() };
            }
        }
        public async Task<List<OrderDto>> GetOrdersBetweenTwoDates(DateTime startingDate, DateTime endingDate)
        {
            try
            {
                var orders = await _context.Orders.Where(o => o.OrderDate>= startingDate&&o.OrderDate<=endingDate).ToListAsync();
                var orderDtos = new List<OrderDto>();
                foreach (var order in orders)
                {
                    var orderDto = new OrderDto
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        EmployeeId = order.EmployeeId,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    };
                    orderDtos.Add(orderDto);
                }
                return orderDtos;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OrderDto> { new OrderDto() };
            }
        }
        public async Task<List<int>> GetHighestOrderCustomer()
        {
            var highestOrderCustomers = await _context.Orders.GroupBy(o => o.CustomerId).Select(g => new { customeId = g.Key, orderCount = g.Count() }).OrderByDescending(x => x.orderCount).ToListAsync();
            var highestOrderCustomerIds=new List<int>();
            foreach(var c in highestOrderCustomers)
            {
                highestOrderCustomerIds.Add(c.customeId);
            }
            return highestOrderCustomerIds;
        }
    }
}
