using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    /// <summary>
    /// storelocation class. Contains storelocation fields and constructor
    /// </summary>
    public class StoreLocation
    {
        public int StoreLocationId { get; }
        public string StoreLocationName { get; }

        public StoreLocation() { }

        public StoreLocation(int id, string name)
        {
            StoreLocationId = id;
            StoreLocationName = name;
        }
    }
}
