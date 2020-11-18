using Project0.BusinessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    public class Order : IOrder
    {
        public int OrderId { get; }
        public int OrderCustomerId { get; }
        public DateTime OrderTime { get; }
        public int OrderStoreLocationId { get; }
        public decimal OrderTotal { get; }

        public Order(int id, Customer cust, DateTime time, StoreLocation location, decimal total)
        {
            OrderId = id;
            OrderCustomerId = cust.CustomerId;
            OrderTime = time;
            OrderStoreLocationId = location.StoreLocationId;
            OrderTotal = total;
        }
    }
}
