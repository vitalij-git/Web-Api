using BackEnd.Models;
using BackEnd.Models.Dto.Orders;

namespace BackEnd.Services
{
    public interface IOrderService
    {
        public Task CreateOrder(OrderDto orderDto);
        public Task<IList<Order>> GetOrders();
        public Task<Order> GetOrder(int orderId);
        public Task DeleteOrder(int orderId);
    }
}