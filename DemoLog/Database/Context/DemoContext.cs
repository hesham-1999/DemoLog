using DemoLog.Dmoain.OrderAgg;
using Microsoft.EntityFrameworkCore;

namespace DemoLog.Database.Context
{
    public class DemoContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DemoContext(DbContextOptions<DemoContext> options) :base(options) 
        {
            
        }

    }
}
