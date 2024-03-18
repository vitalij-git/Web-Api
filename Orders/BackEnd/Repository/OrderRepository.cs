using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseConnection _connection;

        public OrderRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateOrder(Order order)
        {
            _connection.Orders.Add(order);
            await _connection.SaveChangesAsync();
        }

        public async Task DeleteOrder(int orderId)
        {
            var request = await _connection.Orders.FirstOrDefaultAsync(_ => _.Id == orderId);
            if (request != null)
            {
                _connection.Orders.Remove(request);
                await _connection.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrder(int orderId)
        {
            var request = await _connection.Orders.FirstOrDefaultAsync(_ => _.Id == orderId);
            if (request != null) { 
                return request;
            }
            return null;
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _connection.Orders.ToListAsync();  
        }
    }
}
