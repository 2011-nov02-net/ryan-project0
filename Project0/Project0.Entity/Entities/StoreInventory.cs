using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class StoreInventory
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int ProductQty { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
