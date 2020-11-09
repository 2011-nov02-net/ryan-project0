using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    /// <summary>
    /// Product Class
    /// Contains all the methods and fields for the product objects
    /// </summary>
    public class Product
    {
        //fields
        public int ProductID { get; }
        public string ProductName { get; }
        public int ProductInventory { get; private set; }
        public double ProductPrice { get; }

        //constructor
        public Product(int id, string name, int inv, double price)
        {
            ProductID = id;
            ProductName = name;
            ProductInventory = inv;
            ProductPrice = price;
        }
    }
}
