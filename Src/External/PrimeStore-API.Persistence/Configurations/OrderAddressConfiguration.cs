using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class OrderAddressConfiguration:BaseConfiguration<OrderAddress>
    {
        public override void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.Property(x => x.AddressType).HasConversion<string>();
            builder.Property(x => x.AddressLine1).HasMaxLength(500).IsRequired();
            builder.Property(x => x.AddressLine2).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.DistrictName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CityName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CountryName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PostCode).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.PersonName).HasMaxLength(300).IsRequired();
            base.Configure(builder);
        }
    }
}
