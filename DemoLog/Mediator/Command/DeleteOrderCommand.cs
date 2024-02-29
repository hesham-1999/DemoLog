using MediatR;

namespace DemoLog.Mediator.Command
{
    public class DeleteOrderCommand :IRequest
    {
        public int OrderId { get;private set;}
        public DeleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
