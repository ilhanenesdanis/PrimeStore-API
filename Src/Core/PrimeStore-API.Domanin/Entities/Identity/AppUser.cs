using Microsoft.AspNetCore.Identity;

namespace PrimeStore_API.Domanin.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return $"{Name} {Surname}"; } }
        public string? IdentityNumber { get; set; }

        //Relationships
        public ICollection<UserAddress> UserAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
