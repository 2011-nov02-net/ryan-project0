using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    public class Location
    {
        //fields
        public string LocationName { get; }
        public List<Product> Inventory { get; private set; } = new List<Product>();

        //constructor
        public Location(string name, List<Product> p)
        {
            LocationName = name;
            Inventory = p;
        }
    }
}
