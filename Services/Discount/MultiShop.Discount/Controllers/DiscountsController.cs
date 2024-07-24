using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var coupons = await _discountService.GetAllCouponAsync();
            return Ok(coupons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var coupon = await _discountService.GetByIdCouponAsync(id);
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon successfully created.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Coupon successfully deleted.");
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon successfully updated.");
        }
    }
}
