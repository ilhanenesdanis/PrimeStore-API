using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("Brands")]
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public Product Product { get; set; }
    }
}
