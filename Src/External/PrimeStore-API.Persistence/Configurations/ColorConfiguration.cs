using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class ColorConfiguration:BaseConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasIndex(x => x.ColorCode);

            builder.Property(x => x.ColorCode).IsRequired();
            builder.Property(x=>x.ColorName).IsRequired();
            base.Configure(builder);
        }
    }
}
