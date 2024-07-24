namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
    }
}
