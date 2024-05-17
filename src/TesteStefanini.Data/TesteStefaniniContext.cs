using TesteStefanini.Data.Mapppings;
using TesteStefanini.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TesteStefanini.Data
{
    public class TesteStefaniniContext : DbContext
    {
        public TesteStefaniniContext(DbContextOptions<TesteStefaniniContext> opt) : base(opt)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
