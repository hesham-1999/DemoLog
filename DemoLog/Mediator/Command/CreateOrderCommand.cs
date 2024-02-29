using DemoLog.Controllers.Request;
using DemoLog.Controllers.Response;
using MediatR;

namespace DemoLog.Mediator.Command
{
    public class CreateOrderCommand :IRequest<OrderResponse>
    {
        public readonly OrderRequest orderRequest;

        public CreateOrderCommand(OrderRequest orderRequest)
        {
            this.orderRequest = orderRequest;
        }
    }
}
