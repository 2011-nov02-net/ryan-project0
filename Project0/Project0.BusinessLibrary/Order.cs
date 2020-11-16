using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    public class Order
    {
        public int OrderId { get; }
        public int OrderCustomerId { get; }
        public DateTime OrderTime { get; }
        public int OrderStoreLocationId { get; }

        public Order(Customer cust, DateTime time, StoreLocation location)
        {
            OrderCustomerId = cust.CustomerId;
            OrderTime = time;
            OrderStoreLocationId = location.StoreLocationId;
        }
    }
}
