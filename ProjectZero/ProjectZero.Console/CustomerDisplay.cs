using System;
using System.Collections.Generic;
using System.Text;
using ProjectZero.BusinessLibrary;

namespace ProjectZero.ConsoleApp
{
    class CustomerDisplay : IDisplay
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("Stream Game Store Menu");
            Console.WriteLine("-------------------");
        }

        //Display store menu and build/display locations inventory
        public void DisplayStore(Location l)
        {
            List<Product> storeProducts = l.Inventory;
            var inv = new StringBuilder();

            //Console.Clear();
            Console.WriteLine($"\nStream {l.LocationName} Game Console Customer Store Menu");
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
            Console.Write("\nSelect the name of a product to purchase: ");
        }

        public void DisplayPurchase(Product p, int qty)
        {

        }

        //Display users shopping cart
        public void DisplayCart(ShoppingCart sc)
        {

        }

        //display all locations
        public void DisplayLocations()
        {

        }
    }
}
