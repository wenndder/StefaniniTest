using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteStefanini.Domain.Models;

namespace TesteStefanini.Data.Mapppings
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        private const string TABLE_NAME = "orders";
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.HasKey(item => new { item.Id, item.OrderId, item.ProductId });
            builder.Property(item => item.Id).ValueGeneratedOnAdd();

            builder.HasOne(ip => ip.Order)
                   .WithMany()
                   .HasForeignKey(ip => ip.OrderId);

            builder.HasOne(ip => ip.Product)
                   .WithMany()
                   .HasForeignKey(ip => ip.ProductId);
        }
    }
}

