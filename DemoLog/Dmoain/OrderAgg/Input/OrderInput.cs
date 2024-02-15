using DemoLog.Controllers.Request;

namespace DemoLog.Dmoain.OrderAgg.Input
{
    public class OrderInput
    {
        public decimal Total { get; set; }
        public string Name { get; set; }

        public List<OrderItemInput> OrderItems { get; set; } = new List<OrderItemInput>();
    }
}
