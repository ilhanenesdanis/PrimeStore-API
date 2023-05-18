using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Persistence.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreateDate).ValueGeneratedOnAdd();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsEnabled).HasDefaultValue(true);
            builder.Property(x => x.ModifiedUserId).HasDefaultValue("").IsRequired(false);
            builder.Property(x => x.CreatedUserId).HasDefaultValue("").IsRequired(false);
        }
    }
}
