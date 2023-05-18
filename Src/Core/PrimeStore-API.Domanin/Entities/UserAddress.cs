using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Domanin.Entities.Identity;

namespace PrimeStore_API.Domanin.Entities
{
    public class UserAddress : BaseEntity
    {
        public string AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string? PostCode { get; set; }
        public string AddressName { get; set; }
        public bool IsShippingAddress { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsDefaultAddress { get; set; }


        //Relationships
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
