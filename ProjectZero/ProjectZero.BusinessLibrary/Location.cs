using System;
using System.Collections.Generic;
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
    }
}
