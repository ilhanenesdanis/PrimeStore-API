using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Domanin.Enums;

namespace PrimeStore_API.Domanin.Entities
{
    public class OrderAddress : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string PostCode { get; set; }
        public string PersonName { get; set; }
        public AddressType AddressType { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
