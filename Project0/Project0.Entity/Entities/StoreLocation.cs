using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Orders = new HashSet<Order>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
