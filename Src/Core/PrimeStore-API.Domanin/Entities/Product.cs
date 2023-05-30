using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Domanin.Enums;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string ParentProductId { get; set; }
        public string UniqProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductContext { get; set; }
        public string Barcode { get; set; }
        public string Url { get; set; }
        public decimal BasePrice { get; set; }
        public string? Size { get; set; }
        public bool IsSpecialProduct { get; set; }
        public Gender Gender { get; set; }

      

        #region Relationships
        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ProductSuppliers> ProductSuppliers { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
        #endregion
    }
}
