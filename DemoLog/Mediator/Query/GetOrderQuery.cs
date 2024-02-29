using DemoLog.Controllers.Response;
using DemoLog.Dmoain.OrderAgg;
using MediatR;

namespace DemoLog.Mediator.Query
{
    public class GetOrderQuery : IRequest<IEnumerable<OrderResponse>>
    {
    }
}
