using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.Entities;

namespace TakeAway.Comment.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
            
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
