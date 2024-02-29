using AutoMapper;
using DemoLog.Controllers.Request;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg.Input;
using DemoLog.Mediator.Command;
using MediatR;

namespace DemoLog.Mediator.Handeler
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this._mapper = mapper;
            this._orderRepository = orderRepository;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var updateorder = await _orderRepository.GetbyId(request.orderUpdateRequest.Id);
            if (updateorder != null)
            {
                var orderinput = _mapper.Map<OrderUpdateInput>(request.orderUpdateRequest);
                updateorder.Update(orderinput);
                await _orderRepository.SaveSchangesAsync();
                return true;
            }
            return false;
        }
    }
}
