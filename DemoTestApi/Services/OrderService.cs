using Core.DTO.Order;
using Core.Entity;
using DemoTestApi.Infrastructure.Repositories;

namespace DemoTestApi.Services
{
    public class OrderService
    {
        OrderRepository _repository;
        public OrderService(OrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderEntity?> Add(AddOrderRequest request)
        {
            return _repository.Add(request);
        }

        public async Task<OrderEntity?> ChangeStatus(ChangeOrderStatusRequest request)
        {
            return _repository.ChangeOrderStatus(request);
        }

        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
