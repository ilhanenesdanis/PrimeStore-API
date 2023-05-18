using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class SuppliersConfiguration:BaseConfiguration<Suppliers>
    {
        public override void Configure(EntityTypeBuilder<Suppliers> builder)
        {
            builder.HasIndex(x => new { x.Id, x.PhoneNumber, x.Email });
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();

            base.Configure(builder);
        }
    }
}
