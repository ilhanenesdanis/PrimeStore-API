using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("ProductSuppliers")]
    public class ProductSuppliers : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
    }
}
