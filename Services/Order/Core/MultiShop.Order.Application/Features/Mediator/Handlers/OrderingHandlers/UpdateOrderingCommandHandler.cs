using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<UpdateOrderingCommand>.Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await _repository.GetByIdAsync(request.Id);
            ordering.OrderDate = request.OrderDate;
            ordering.TotalPrice = request.TotalPrice;
            ordering.UserId = request.UserId;
            await _repository.UpdateAsync(ordering);
        }
    }
}
