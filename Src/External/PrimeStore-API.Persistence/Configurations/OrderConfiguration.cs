using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class OrderConfiguration:BaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasIndex(x => new { x.TrackingNumber, x.Id });

            builder.Property(x => x.OrderTotalPrice).IsRequired();
            builder.Property(x => x.OrderTotalShipping).IsRequired();
            builder.Property(x => x.OrderTotalDiscount).IsRequired();
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.OrderNote).IsRequired(false);
            builder.Property(x => x.TrackingNumber).IsRequired();
            builder.Property(x => x.CouponCode).IsRequired(false);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.OrderCustomerId);
            builder.HasOne(x => x.OrderStatus).WithOne(x => x.Order).HasForeignKey<Order>(x => x.OrderStatusId);
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(x => x.OrderHistories).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(x => x.OrderAddresses).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);

            base.Configure(builder);
        }
    }
}
