﻿using Dapper.Contrib.Extensions;
using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Domanin.Entities
{
    [Table("OrderHistories")]
    public class OrderHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
