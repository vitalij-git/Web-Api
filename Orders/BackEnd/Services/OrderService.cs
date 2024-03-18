using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Dto.Orders;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(OrderDto orderDto)
        {
            Order order = new Order()
            {
                State = orderDto.State,
                Name = orderDto.Name,
            };
            await _orderRepository.CreateOrder(order);
        }

        public async Task DeleteOrder(int orderId)
        {
            await _orderRepository.DeleteOrder(orderId);    
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await _orderRepository.GetOrder(orderId);  
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
    }
}
