using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("ProductStocks")]
    public class ProductStock:BaseEntity
    {
        public string UniqProductId { get; set; }
        public int StockCount { get; set; }

        #region Relationships
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid SupperlierId { get; set; }
        public Suppliers Suppliers { get; set; }


        #endregion
    }
}
