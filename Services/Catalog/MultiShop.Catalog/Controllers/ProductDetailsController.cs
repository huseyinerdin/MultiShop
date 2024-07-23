using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var productDetails = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(productDetail);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail successfully created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail successfully deleted.");
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail successfully updated.");
        }
    }
}
