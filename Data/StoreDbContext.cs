using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<OrderDetail>().HasKey(c => new { c.OrderID, c.ProductID });
        }
    }
}
