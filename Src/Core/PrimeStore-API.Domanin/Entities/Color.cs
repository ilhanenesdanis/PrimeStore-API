using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class Color:BaseEntity
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string ColorHtmlCode { get; set; }
        public Product Product { get; set; }
    }
}
