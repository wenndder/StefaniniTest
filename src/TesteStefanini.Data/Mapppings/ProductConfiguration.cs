using TesteStefanini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteStefanini.Data.Mapppings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private const string TABLE_NAME = "products";

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.ToTable(TABLE_NAME);
            builder.Property(product => product.Id).ValueGeneratedOnAdd();
        }
    }
}
