using DemoLog.Database.Context;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg;
using Microsoft.EntityFrameworkCore;

namespace DemoLog.Database.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DemoContext _context;

        public OrderRepository(DemoContext context)
        {
            this._context = context;
        }
        public void Create(Order order)
        {
           _context.Orders.Add(order);
        }
        public async Task<Order> Getbyid(int id)
        {
            var  order = await _context.Orders.Include(o=>o.Orderitems).FirstOrDefaultAsync(o => o.Id == id);

            return order;

        }

      
        public async Task<IEnumerable<Order>> getAllAsyn()
        {
         return await  _context.Orders.Include(o => o.Orderitems).ToListAsync();
        }

        public async Task SaveSchangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}
