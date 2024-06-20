using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Id)
                .HasConversion(
                lineItemId => lineItemId.Value,
                value => new LineItemId(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            builder.OwnsOne(li => li.Price);
        }
    }
}
