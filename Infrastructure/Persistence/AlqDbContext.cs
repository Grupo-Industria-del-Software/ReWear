using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class AlqDbContext : DbContext
    {
        public AlqDbContext(DbContextOptions<AlqDbContext> options) : base(options)
        {
        }

        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Municipality>()
                .HasOne(m => m.Department)  // Propiedad de navegación en Municipality
                .WithMany(d => d.municipalities) // Propiedad de navegación en Department
                .HasForeignKey(m => m.DepartmentId) // Llave foránea en Municipality
                .OnDelete(DeleteBehavior.Cascade); 
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Value objects
        }
    }
}
