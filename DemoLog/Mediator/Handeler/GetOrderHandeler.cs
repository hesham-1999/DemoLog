using AutoMapper;
using Azure;
using DemoLog.Controllers.Response;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg;
using DemoLog.Mediator.Query;
using MediatR;

namespace DemoLog.Mediator.Handeler
{
    public class GetOrderHandeler : IRequestHandler<GetOrderQuery, IEnumerable<OrderResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderHandeler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var resultModel = await _orderRepository.getAllAsyn();
            var respose = _mapper.Map<List<OrderResponse>>(resultModel);
            return respose;
        }
    }
}
