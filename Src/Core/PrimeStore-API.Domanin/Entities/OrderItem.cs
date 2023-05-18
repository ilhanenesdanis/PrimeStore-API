using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class OrderItem : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public string UniqProductCode { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int UnitCount { get; set; }


        #region Relationships
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
