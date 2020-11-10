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
        public string StoreLocation { get; }
        public Customer OrderCustomer { get; }
        public DateTime OrderTime { get; }
        public Dictionary<Product, int> OrderItems = new Dictionary<Product, int>();
        private List<Order> orderList = new List<Order>();

        //Constructor
        public Order(Location l, Customer c, DateTime time, Dictionary<Product, int> items)
        {
            StoreLocation = l.LocationName;
            OrderCustomer = c;
            OrderTime = time;
            OrderItems = items;
        }

        public void AddToOrderList(Order o)
        {
            orderList.Add(o);

            //update file
            FileWriter fw = new FileWriter();
            fw.WriteOrder(o, "../../../Data/Orders.json");
        }

        public List<Order> GetOrderList()
        {
            //always get upto date order list
            FileReader fr = new FileReader();
            orderList = fr.ReadOrders("../../../Data/Orders.json");

            return orderList;
        }
    }
}
