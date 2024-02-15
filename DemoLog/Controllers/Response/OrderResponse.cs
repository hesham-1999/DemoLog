namespace DemoLog.Controllers.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Name { get; set; }

        public List<orderItemRespose> Orderitems { get; set; }  = new List<orderItemRespose>();
    }
}
