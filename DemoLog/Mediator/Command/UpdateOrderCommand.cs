using DemoLog.Controllers.Request;
using MediatR;

namespace DemoLog.Mediator.Command
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public readonly OrderUpdateRequest orderUpdateRequest ;
        public UpdateOrderCommand(OrderUpdateRequest orderUpdateRequest)
        {
             this.orderUpdateRequest = orderUpdateRequest ;
        }

    }
}
