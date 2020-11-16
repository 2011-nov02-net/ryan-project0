using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class StoreLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InventoryId { get; set; }

        public virtual StoreInventory Inventory { get; set; }
    }
}
