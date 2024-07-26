using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var addresses = await _getAddressQueryHandler.Handle();
            return Ok(addresses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var address = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Address successfully created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok("Address successfully deleted.");
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Address successfully updated.");
        }
    }
}
