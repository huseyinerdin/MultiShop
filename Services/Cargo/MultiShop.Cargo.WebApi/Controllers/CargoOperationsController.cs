using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var operations = _cargoOperationService.TGetAll();
            return Ok(operations);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var operation = _cargoOperationService.TGetById(id);
            return Ok(operation);
        }
        [HttpPost]
        public IActionResult Post(CreateCargoOperationDto createCargoOperationDto)
        {
            var operation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TCreate(operation);
            return Ok("Cargo operation successfully created.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Cargo operation successfully deleted.");
        }
        [HttpPut]
        public IActionResult Put(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var operation = new CargoOperation()
            {
                Id = updateCargoOperationDto.Id,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TUpdate(operation);
            return Ok("Cargo operation successfully updated.");
        }
    }
}
