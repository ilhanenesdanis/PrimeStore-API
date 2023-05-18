using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => new { x.Barcode, x.UniqProductId, x.Id });
            builder.Property(x => x.ParentProductId).IsRequired(false);
            builder.Property(x => x.UniqProductId).IsRequired();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductTitle).IsRequired();
            builder.Property(x => x.Barcode).IsRequired();
            builder.Property(x => x.IsSpecialProduct).HasDefaultValue(false);

            builder.Property(x => x.Gender).HasConversion<string>();

            builder.HasOne(x => x.Color).WithOne(x => x.Product).HasForeignKey<Product>(x => x.ColorId);
            builder.HasOne(x => x.Brand).WithOne(x => x.Product).HasForeignKey<Product>(x => x.BrandId);
            builder.HasMany(x => x.ProductSuppliers).WithOne(x => x.Product).HasForeignKey(x => x.SupplierId);
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(x => x.ProductStocks).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
