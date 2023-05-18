using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class Suppliers : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<ProductSuppliers> ProductSuppliers { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
