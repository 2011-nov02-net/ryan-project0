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
            Console.Write("\nSelect the name of a product to purchase or (c) to view cart or (q) to quit: ");
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
        public bool DisplayCart(ShoppingCart sc)
        {
            Console.WriteLine("Name\t\tPrice\tQuantity");
            var lines = sc.Cart.Select(kvp => kvp.Key.ProductName + "\t " + kvp.Key.ProductPrice + "\t " + kvp.Value.ToString());
            Console.WriteLine(string.Join(Environment.NewLine, lines));

            string input = "";
            while (!input.Equals("y", StringComparison.InvariantCultureIgnoreCase) || !input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                //prompt for checkout
                Console.Write("\nWould you like to checkout? y/n: ");
                input = Console.ReadLine();

                if (input.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else if (input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try Again.");
                }
            }
            return false;
        }

        public void DisplayCheckout(Order o, Location l)
        {
            double total = 0.0;
            Console.WriteLine($"\n{o.OrderCustomer.CustomerFirstName}'s Order at {o.OrderTime} from {o.StoreLocation}: ");
            Console.WriteLine("-----------------------");
            foreach(var item in o.OrderItems)
            {
                total += item.Value * item.Key.ProductPrice;
                Console.WriteLine($"{item.Key.ProductName}\t\t${item.Key.ProductPrice}\t{item.Value} : ${item.Value * item.Key.ProductPrice}");
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Grand Total: $" + total);

            Console.Write("Would you like to purchase the order (y/n): ");
            string input = "";
            while (!input.Equals("y", StringComparison.InvariantCultureIgnoreCase) || !input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                input = Console.ReadLine();
                if (input.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    //log the order
                    o.AddToOrderList(o);

                    //update locations inventory
                    foreach(var product in o.OrderItems)
                    {
                        l.UpdateProductQty(product.Key, product.Value);
                    }

                    Console.WriteLine("Order Purchased!");
                    break;
                }
                else if (input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try Again.");
                }
            }
        }

        //display all locations
        public void DisplayLocations()
        {

        }
    }
}
