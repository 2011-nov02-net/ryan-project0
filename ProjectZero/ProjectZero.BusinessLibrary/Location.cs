using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectZero.BusinessLibrary
{
    public class Location
    {
        //fields
        [JsonPropertyName("storename")]
        public string LocationName { get; }

        [JsonPropertyName("inventory")]
        public List<Product> Inventory { get; private set; } = new List<Product>();

        //deafult constructor
        public Location() { }

        //constructor
        public Location(string name)
        {
            LocationName = name;
        }

        public void AddProduct(Product p)
        {
            Inventory.Add(p);
        }

        public void UpdateProductQty(Product p, int qty)
        {
            foreach(var product in Inventory)
            {
                if(product == p)
                {
                    if(product.ProductQty >= qty)
                    {
                        product.ProductQty -= qty;
                    }
                    else
                    {
                        product.ProductQty = 0;
                    }
                   
                }
            }
        }
    }
}
