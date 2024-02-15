namespace DemoLog.Controllers.Request
{
    public class OrderRequest
    {
        public decimal Total { get; set; }
        public string Name { get; set; }

        public List<OrderItemRequest> OrderItems { get; set; } = new List<OrderItemRequest>();
    }
}
