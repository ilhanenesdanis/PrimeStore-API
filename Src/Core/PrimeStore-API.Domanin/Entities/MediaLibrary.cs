using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class MediaLibrary : BaseEntity
    {
        public string LibraryName { get; set; }
        public string FolderName { get; set; }
        public ICollection<MediaLibraryFile> MediaLibraryFiles { get; set; }
    }
}
