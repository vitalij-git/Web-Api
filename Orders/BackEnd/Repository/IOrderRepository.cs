using BackEnd.Models;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace BackEnd.Repository
{
    public interface IOrderRepository
    {
        public Task CreateOrder(Order order);
        public Task<IList<Order>> GetOrders();
        public Task<Order> GetOrder(int orderId);
        public Task DeleteOrder(int orderId);
    }
}