using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    /// <summary>
    /// Order Class
    /// Contains all the methods and fields for the order objects
    /// </summary>
    public class Order
    {
        //Fields
        public Location StoreLocation { get; }
        public Customer OrderCustomer { get; }
        public DateTime OrderTime { get; }
        private List<Product> OrderItems = new List<Product>();

        //Constructor
        public Order(Location l, Customer c, DateTime time, List<Product> items)
        {
            StoreLocation = l;
            OrderCustomer = c;
            OrderTime = time;
            OrderItems = items;
        }

        //get all orders items
        public List<Product> GetOrderItems()
        {
            return null;
        }
    }
}
