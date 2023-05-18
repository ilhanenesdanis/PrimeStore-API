using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class OrderHistoryConfiguration:BaseConfiguration<OrderHistory>
    {
        public override void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            
            builder.HasOne(x => x.Order).WithMany(x => x.OrderHistories).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.OrderStatus).WithMany(x => x.OrderHistories).HasForeignKey(x => x.OrderStatusId);

            base.Configure(builder);
        }
    }
}
