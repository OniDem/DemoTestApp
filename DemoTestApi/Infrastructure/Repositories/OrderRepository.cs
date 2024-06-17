using Core.Const;
using Core.DTO.Order;
using Core.Entity;

namespace DemoTestApi.Infrastructure.Repositories
{
    public class OrderRepository
    {
        ApplicationContext _applicationContext;

        public OrderRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public OrderEntity Add(AddOrderRequest request)
        {
            OrderEntity order = new()
            {
                Table = request.Table,
                ClientCount = request.ClientCount,
                OrderText = request.OrderText,
                Status = StatusConst.OrderOpened
            };
            _applicationContext.Orders.Add(order);
            _applicationContext.SaveChanges();
            return order;
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _applicationContext.Orders.AsEnumerable();
        }

        public OrderEntity? GetOrderById(GetOrderByIdRequest request)
        {
            return _applicationContext.Orders.FirstOrDefault(x => x.OrderId == request.OrderID);
        }

        public OrderEntity? ChangeOrderStatus(ChangeOrderStatusRequest request)
        {
            var order = GetOrderById(new() { OrderID = request.OrderId });
            order.Status = request.Status;
            _applicationContext.Update(order);
            _applicationContext.SaveChanges();
            return order;
        }
    }
}
