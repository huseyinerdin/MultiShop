using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var orderDetail = await _repository.GetByIdAsync(updateOrderDetailCommand.Id);
            orderDetail.OrderingId = updateOrderDetailCommand.OrderingId;
            orderDetail.ProductAmount = updateOrderDetailCommand.ProductAmount;
            orderDetail.ProductId = updateOrderDetailCommand.ProductId;
            orderDetail.ProductName = updateOrderDetailCommand.ProductName;
            orderDetail.ProductPrice = updateOrderDetailCommand.ProductPrice;
            orderDetail.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            await _repository.UpdateAsync(orderDetail);
        }
    }
}
