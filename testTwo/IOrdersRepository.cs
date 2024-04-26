using testTwo.Models;

namespace testTwo
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}