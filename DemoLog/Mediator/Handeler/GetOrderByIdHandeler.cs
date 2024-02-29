using AutoMapper;
using DemoLog.Controllers.Response;
using DemoLog.Dmoain;
using DemoLog.Mediator.Query;
using MediatR;

namespace DemoLog.Mediator.Handeler
{
    public class GetOrderByIdHandeler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdHandeler(IMapper mapper , IOrderRepository orderRepository)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
        }
        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetbyId(request.id);
            var orderRespons = _mapper.Map<OrderResponse>(order);

            return orderRespons;
        }
    }
}
