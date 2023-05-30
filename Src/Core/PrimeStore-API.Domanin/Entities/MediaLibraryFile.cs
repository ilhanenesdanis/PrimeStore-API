using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("MediaLibraryFiles")]
    public class MediaLibraryFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public decimal FileHeight { get; set; }
        public decimal FileWith { get; set; }
        public decimal FileSize { get; set; }
        public string? FileUrl { get; set; }
        public string? FileExternalUrl { get; set; }

        public Guid MediaLibraryId { get; set; }
        public MediaLibrary MediaLibrary { get; set; }
    }
}
