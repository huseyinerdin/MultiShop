using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _cargoCompanyService.TGetAll();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _cargoCompanyService.TGetById(id);
            return Ok(company);
        }
        [HttpPost]
        public IActionResult Post(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var company = new CargoCompany()
            {
                Name = createCargoCompanyDto.Name
            };
            _cargoCompanyService.TCreate(company);
            return Ok("Cargo company successfully created.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Cargo company successfully deleted.");
        }
        [HttpPut]
        public IActionResult Put(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var company = new CargoCompany()
            {
                Name = updateCargoCompanyDto.Name,
                Id = updateCargoCompanyDto.Id
            };
            _cargoCompanyService.TUpdate(company);
            return Ok("Cargo company successfully updated.");
        }
    }
}
