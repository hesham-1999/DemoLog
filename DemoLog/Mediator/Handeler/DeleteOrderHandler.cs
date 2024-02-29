using AutoMapper;
using DemoLog.Dmoain;
using DemoLog.Dmoain.OrderAgg;
using DemoLog.Mediator.Command;
using MediatR;

namespace DemoLog.Mediator.Handeler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var deletedorder = await _orderRepository.GetbyId(request.OrderId);
            deletedorder.Delete();
            await _orderRepository.SaveSchangesAsync();
        }

    }
}
