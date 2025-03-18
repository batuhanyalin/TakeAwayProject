using Dapper;
using TakeAwayProject.Discount.Context;
using TakeAwayProject.Discount.Dtos;

namespace TakeAwayProject.Discount.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly DapperContext _context;

        public DiscountCouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto dto)
        {
            string query = "insert into DiscountCoupons (Code,Rate,IsActive) values (@code,@rate,@IsActive)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@IsActive", dto.IsActive);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from DiscountCoupons where DiscountCouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select * from DiscountCoupons where DiscountCouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
            return value;
        }

        public async Task<List<ResultDiscountCouponDto>> GetResultDiscountCouponAsync()
        {
            string query = "select * from DiscountCoupons";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto dto)
        {
            string query = "update DiscountCoupons set Code=@code,Rate=@rate,IsActive=@IsActive where DiscountCouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", dto.DiscountCouponId);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@code", dto.Code);
            parameters.Add("@IsActive", dto.IsActive);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
