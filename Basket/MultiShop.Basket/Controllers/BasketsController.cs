using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var basket = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Basket successfully created.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok("Basket successfully deleted.");
        }
    }
}
