using System;
using System.Collections.Generic;
using System.Linq;
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
                inv.AppendLine($"{item.ProductID}\t{item.ProductName}\t{item.ProductPrice}\t{item.ProductQty}");
            }
            //Print
            Console.WriteLine(inv.ToString());
            Console.Write("\nSelect the name of a product to purchase or (c) to view cart: ");
        }

        public void DisplayPurchase(Product p, int qty)
        {

        }

        public (string, string) DisplayNamesGet()
        {
            //needs validation
            Console.Write("Enter Your First Name: ");
            string first = Console.ReadLine();

            Console.Write("\nEnter Your Last Name: ");
            string last = Console.ReadLine();

            return (first, last);
        }

        //Display users shopping cart
        public void DisplayCart(ShoppingCart sc)
        {
            Console.WriteLine("Name\t\tPrice\tQuantity");
            var lines = sc.Cart.Select(kvp => kvp.Key.ProductName + "\t " + kvp.Key.ProductPrice + "\t " + kvp.Value.ToString());
            Console.WriteLine(string.Join(Environment.NewLine, lines)); 
        }

        //display all locations
        public void DisplayLocations()
        {

        }
    }
}
