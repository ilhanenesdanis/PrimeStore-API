using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }

        public Order Order { get; set; }

        public ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
