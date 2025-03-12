using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AlqDbContext : DbContext
    {
        public AlqDbContext(DbContextOptions<AlqDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
