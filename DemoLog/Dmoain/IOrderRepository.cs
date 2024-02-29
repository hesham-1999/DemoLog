using DemoLog.Dmoain.OrderAgg;

namespace DemoLog.Dmoain
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> getAllAsyn();
        void Create(Order order);
         Task<Order> GetbyId(int id);
        Task SaveSchangesAsync();
    }
}
