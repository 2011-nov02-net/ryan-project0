using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    public class StoreInventory
    {
        public int StoreInventoryLocationId { get; }
        public int StoreInventoryProductId { get; }
        public int StoreInventoryProductQty { get; }

        public StoreInventory( StoreLocation storeId)
        {
            StoreInventoryLocationId = storeId.StoreLocationId;
        }

        //Add product or increase quantity in stock
        public void AddProduct(int productId, int qty)
        {
            //sql to update product qty in table
        }

        //Remove product or decrease quantity in stock
        public void RemoveProduct(int productId, int qty)
        {
            //sql to update product qty in table
        }
    }
}
