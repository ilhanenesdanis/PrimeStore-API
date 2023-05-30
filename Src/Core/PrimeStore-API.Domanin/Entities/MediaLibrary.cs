using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("MediaLibraries")]
    public class MediaLibrary : BaseEntity
    {
        public string LibraryName { get; set; }
        public string FolderName { get; set; }
        public ICollection<MediaLibraryFile> MediaLibraryFiles { get; set; }
    }
}
