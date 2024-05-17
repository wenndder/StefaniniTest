using TesteStefanini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteStefanini.Data.Mapppings
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        private const string TABLE_NAME = "orders";

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.ToTable(TABLE_NAME);
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
        }
    }
}
