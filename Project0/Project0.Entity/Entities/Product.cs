using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
