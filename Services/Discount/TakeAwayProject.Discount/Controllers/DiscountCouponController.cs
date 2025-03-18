using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayProject.Discount.Dtos;
using TakeAwayProject.Discount.Services;

namespace TakeAwayProject.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountCouponController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _discountCouponService.GetResultDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCoupon(int id)
        {
            var value = await _discountCouponService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto dto)
        {
            await _discountCouponService.CreateDiscountCouponAsync(dto);
            return Ok("İndirim kuponu başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto dto)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(dto);
            return Ok("İndirim kuponu başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await   _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("İndirip kuponu başarıyla silindi.");
        }
    }
}
