using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class ProductStockConfiguration : BaseConfiguration<ProductStock>
    {
        public override void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasIndex(x => x.UniqProductId);

            builder.Property(x => x.UniqProductId).IsRequired();
            builder.Property(x => x.StockCount).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductStocks).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Suppliers).WithMany(x => x.ProductStocks).HasForeignKey(x => x.SupperlierId);


            base.Configure(builder);
        }
    }
}
