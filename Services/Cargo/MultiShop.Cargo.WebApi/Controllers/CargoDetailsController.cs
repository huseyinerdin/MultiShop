using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var details = _cargoDetailService.TGetAll();
            return Ok(details);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var detail = _cargoDetailService.TGetById(id);
            return Ok(detail);
        }
        [HttpPost]
        public IActionResult Post(CreateCargoDetailDto createCargoDetailDto)
        {
            var detail = new CargoDetail() { 
                Barcode = createCargoDetailDto.Barcode, 
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TCreate(detail);
            return Ok("Cargo detail successfully created.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Cargo detail successfully deleted.");
        }
        [HttpPut]
        public IActionResult Put(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var detail = new CargoDetail()
            {
                Id = updateCargoDetailDto.Id,
                Barcode = updateCargoDetailDto.Barcode,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TUpdate(detail);
            return Ok("Cargo detail successfully updated.");
        }
    }
}
