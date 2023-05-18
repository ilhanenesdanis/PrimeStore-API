using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class UserAddressConfiguration:BaseConfiguration<UserAddress>
    {
        public override void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            base.Configure(builder);
        }
    }
}
