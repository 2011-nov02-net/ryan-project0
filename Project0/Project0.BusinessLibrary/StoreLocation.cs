using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    public class StoreLocation
    {
        public int StoreLocationId { get; }
        public string StoreLocationName { get; }
        public int StoreLocationInventoryId { get; }

        public StoreLocation(int id, string name, int invId)
        {
            StoreLocationId = id;
            StoreLocationName = name;
            StoreLocationInventoryId = invId;
        }
    }
}
