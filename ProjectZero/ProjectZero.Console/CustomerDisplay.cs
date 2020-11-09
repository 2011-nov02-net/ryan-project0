using System;
using System.Collections.Generic;
using System.Text;
using ProjectZero.BusinessLibrary;

namespace ProjectZero.ConsoleApp
{
    class CustomerDisplay : IDisplay
    {
        //Display store menu and build/display locations inventory
        public void DisplayStore(Location l)
        {
            List<Product> storeProducts = l.Inventory;
            var inv = new StringBuilder();

            Console.Clear();
            Console.WriteLine($"\nBLANK {l.LocationName} Console Customer Store Menu");
            Console.WriteLine("--------------------------------------------------");

            //Header line
            inv.AppendLine("ID\t\tName\tPrice\tQuantity");
            //Build Output
            foreach (var item in storeProducts)
            {
                inv.AppendLine($"{item.ProductID}\t{item.ProductName}\t{item.ProductPrice}\t{item.ProductInventory}");
            }
            //Print
            Console.WriteLine(inv.ToString());
        }
        //Display users shopping cart
        public void DisplayCart(ShoppingCart sc)
        {

        }
    }
}
