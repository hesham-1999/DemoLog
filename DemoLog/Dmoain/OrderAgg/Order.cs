using DemoLog.Dmoain.OrderAgg.Base;
using DemoLog.Dmoain.OrderAgg.Input;

namespace DemoLog.Dmoain.OrderAgg
{
    public class Order :BaseEntity
    {
        public decimal Total { get;private set; }
        private readonly List<orderItem> _orderitems = new List<orderItem>();
        public virtual IReadOnlyList<orderItem> Orderitems { get {  return _orderitems.ToList(); } }
        public Order()
        {}
        public Order(OrderInput input)
        {
            this.CratedAt = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Name = input.Name;
            this.Total = input.Total;
            foreach (var item in input.OrderItems)
            {
                _orderitems.Add(new orderItem(item));
            }
        }
        public void Delete()
        {
            this.IsDeleted=true;
            foreach (var item in this._orderitems)
            {
                item.Delete();
            }

        }
        public void Update(OrderUpdateInput orderUpdateInput)
        {
            this.Name=orderUpdateInput.Name;
            this.Total = orderUpdateInput.Total;
            foreach (var item in orderUpdateInput.OrderItems)
            {
               var orderItem =  _orderitems.Where(oi => oi.Id == item.Id).SingleOrDefault();
                if(orderItem != null)
                {
                    orderItem.Update(item);
                }
            }
        }
    }
}
