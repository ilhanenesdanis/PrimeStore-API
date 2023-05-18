using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class ProductSuppliersConfiguration:BaseConfiguration<ProductSuppliers>
    {
        public override void Configure(EntityTypeBuilder<ProductSuppliers> builder)
        {
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.OldPrice).IsRequired();

            builder.HasOne(x => x.Supplier).WithMany(x => x.ProductSuppliers).HasForeignKey(x => x.SupplierId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductSuppliers).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
