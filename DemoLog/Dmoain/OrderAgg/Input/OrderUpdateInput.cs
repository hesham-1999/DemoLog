namespace DemoLog.Dmoain.OrderAgg.Input
{
    public class OrderUpdateInput
    {
        public decimal Total { get; set; }
        public string Name { get; set; }

        public List<OrderItemUpdateInput> OrderItems { get; set; } = new List<OrderItemUpdateInput>();
    }
}
