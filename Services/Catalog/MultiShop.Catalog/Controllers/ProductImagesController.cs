using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var productImages = await _productImageService.GetAllProductImagesAsync();
            return Ok(productImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var productImage = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(productImage);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage successfully created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage successfully deleted.");
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("ProductImage successfully updated.");
        }
    }
}
