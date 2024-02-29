using DemoLog.Controllers.Response;
using MediatR;

namespace DemoLog.Mediator.Query
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public int id { get; private set; }
        public GetOrderByIdQuery(int id) 
        {
            this.id = id;
        }

    }
}
