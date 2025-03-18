using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TakeAwayProject.Discount.Entities;

namespace TakeAwayProject.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Key");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=TakeAwayDiscountDb;integrated security=true");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
    }
}
