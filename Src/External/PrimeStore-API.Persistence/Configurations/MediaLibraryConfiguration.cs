using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeStore_API.Domanin.Entities;

namespace PrimeStore_API.Persistence.Configurations
{
    public class MediaLibraryConfiguration:BaseConfiguration<MediaLibrary>
    {
        public override void Configure(EntityTypeBuilder<MediaLibrary> builder)
        {
            builder.Property(x => x.LibraryName).IsRequired();
            builder.Property(x => x.FolderName).IsRequired();
            builder.HasMany(x => x.MediaLibraryFiles).WithOne(x => x.MediaLibrary).HasForeignKey(x => x.MediaLibraryId);
            base.Configure(builder);
        }
    }
}
