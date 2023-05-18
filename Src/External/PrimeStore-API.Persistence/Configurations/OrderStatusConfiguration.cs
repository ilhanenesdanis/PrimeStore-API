using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class OrderStatusConfiguration:BaseConfiguration<OrderStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            base.Configure(builder);
        }
    }
}
