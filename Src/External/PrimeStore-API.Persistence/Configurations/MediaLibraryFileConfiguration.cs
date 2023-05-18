using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class MediaLibraryFileConfiguration:BaseConfiguration<MediaLibraryFile>
    {
        public override void Configure(EntityTypeBuilder<MediaLibraryFile> builder)
        {
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileExtension).IsRequired().HasMaxLength(30);
            builder.Property(x => x.FilePath).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileUrl).IsRequired(false).HasMaxLength(300);
            builder.Property(x => x.FileExternalUrl).IsRequired(false).HasMaxLength(300);
            
            base.Configure(builder);
        }
    }
}
