using AutoMapper;
using DemoLog.Controllers.Request;
using DemoLog.Controllers.Response;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg.Input;
using DemoLog.Dmoain.OrderAgg;
using DemoLog.Mediator.Command;
using MediatR;

namespace DemoLog.Mediator.Handeler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
        }
        public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orederInput = _mapper.Map<OrderInput>(command.orderRequest);
            var order = new Order(orederInput);
            _orderRepository.Create(order);
            await _orderRepository.SaveSchangesAsync();
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }
    }
}
