using BackEnd.ErrorResponseModel;
using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Dto.Orders;
using BackEnd.Repository;
using System.Net;

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
            if (string.IsNullOrEmpty(orderDto.Name))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Name cannot be empty");
            }
            else if(string.IsNullOrEmpty(orderDto.State))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "State cannot be empty");
            }
            else
            {
                Order order = new Order()
                {
                    State = orderDto.State,
                    Name = orderDto.Name,
                };
                await _orderRepository.CreateOrder(order);
            }

        }

        public async Task DeleteOrder(int orderId)
        {
            if(orderId == null || orderId == 0) 
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");

            }
                await _orderRepository.DeleteOrder(orderId);

        }

        public async Task<Order> GetOrder(int orderId)
        {
            if(orderId == null || orderId == 0)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");
                
            }
                return await _orderRepository.GetOrder(orderId);    
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
    }
}
