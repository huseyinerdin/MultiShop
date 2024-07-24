namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public int Id { get; set; }

        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}
