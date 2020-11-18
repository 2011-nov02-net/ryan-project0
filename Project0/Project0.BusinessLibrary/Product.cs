using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    /// <summary>
    /// product class. Contains product fields and constructor
    /// </summary>
    public class Product
    {
        public int ProductId { get; }
        public string ProductName { get; }
        public double ProductPrice { get; }
        public int ProductQty { get; }

        public Product(int id, string name, double price, int qty)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductQty = qty;
        }
    }
}

