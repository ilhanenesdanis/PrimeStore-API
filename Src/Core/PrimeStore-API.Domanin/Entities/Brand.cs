using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public Product Product { get; set; }
    }
}
