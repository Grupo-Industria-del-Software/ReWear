using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class AlqDbContext : DbContext
    {
        public AlqDbContext(DbContextOptions<AlqDbContext> options) : base(options)
        {
        }


        public DbSet<OrderType> OrderTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
