using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class OrderItemConfiguration : BaseConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasIndex(x => x.UniqProductCode);

            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductSize).IsRequired(false);
            builder.Property(x => x.UniqProductCode).IsRequired();
            builder.Property(x => x.ProductUnitPrice).IsRequired();
            builder.Property(x => x.ProductTotalPrice).IsRequired();
            builder.Property(x => x.UnitCount).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);

            base.Configure(builder);
        }
    }
}
