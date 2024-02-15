using DemoLog.Dmoain.OrderAgg.Base;
using DemoLog.Dmoain.OrderAgg.Input;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoLog.Dmoain.OrderAgg
{
    public class orderItem : BaseEntity
    {
        public decimal Price { get; private set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }
        public orderItem()
        {
            
        }
        public orderItem(OrderItemInput input)
        {
            this.IsDeleted = false;
            this.CratedAt = DateTime.UtcNow;

            this.Name = input.Name;
            this.Price = input.Price;

        }
        public void Delete()
        {
           this.IsDeleted = true;
        }
        public void Update(OrderItemUpdateInput item)
        {
            this.Name=item.Name;
            this.Price = item.Price;
        }
    }
}
