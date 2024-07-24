using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(ordering);
        }
    }
}
