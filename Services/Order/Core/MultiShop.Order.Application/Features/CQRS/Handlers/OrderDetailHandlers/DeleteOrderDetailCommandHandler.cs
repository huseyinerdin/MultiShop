using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteOrderDetailCommand deleteOrderDetailCommand)
        {
            var orderDetail = await _repository.GetByIdAsync(deleteOrderDetailCommand.Id);
            await _repository.DeleteAsync(orderDetail);
        }
    }
}
