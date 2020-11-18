using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual StoreLocation Store { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
