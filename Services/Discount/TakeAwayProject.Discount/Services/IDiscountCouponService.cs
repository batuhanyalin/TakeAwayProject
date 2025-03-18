using TakeAwayProject.Discount.Dtos;

namespace TakeAwayProject.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<List<ResultDiscountCouponDto>> GetResultDiscountCouponAsync();
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto dto);
        Task DeleteDiscountCouponAsync(int id);
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto dto);

        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}
