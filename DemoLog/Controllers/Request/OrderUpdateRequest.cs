namespace DemoLog.Controllers.Request
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Name { get; set; }

        public List<OrderItemUdateRequest> OrderItems { get; set; } = new List<OrderItemUdateRequest>();
    }
}
