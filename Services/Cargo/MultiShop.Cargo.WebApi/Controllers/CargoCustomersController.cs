using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _cargoCustomerService.TGetAll();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _cargoCustomerService.TGetById(id);
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Post(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var customer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                District = createCargoCustomerDto.District,
                City = createCargoCustomerDto.City,
                Address = createCargoCustomerDto.Address,
            };
            _cargoCustomerService.TCreate(customer);
            return Ok("Cargo customer successfully created.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo customer successfully deleted.");
        }
        [HttpPut]
        public IActionResult Put(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var customer = new CargoCustomer()
            {
                Id = updateCargoCustomerDto.Id,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                District = updateCargoCustomerDto.District,
                City = updateCargoCustomerDto.City,
                Address = updateCargoCustomerDto.Address,
            };
            _cargoCustomerService.TUpdate(customer);
            return Ok("Cargo customer successfully updated.");
        }
    }
}
