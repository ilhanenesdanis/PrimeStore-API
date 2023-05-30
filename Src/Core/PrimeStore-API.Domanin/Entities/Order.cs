using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Domanin.Entities.Identity;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        public decimal OrderTotalPrice { get; set; }
        public decimal OrderTotalShipping { get; set; }
        public decimal OrderTotalDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNote { get; set; }
        public string TrackingNumber { get; set; }
        public string CouponCode { get; set; }



        #region Relationships
        public string OrderCustomerId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderHistory> OrderHistories { get; set; }
        public ICollection<OrderAddress> OrderAddresses { get; set; }

        #endregion
    }
}
