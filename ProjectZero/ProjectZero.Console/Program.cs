using ProjectZero.BusinessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectZero.ConsoleApp
{
    class Program
    {
        static Location l;
        static void Main(string[] args)
        {
            //Location l;
            bool runLocation = true;
            //"../../../Data/Locations.json"
            //FileWriter fw = new FileWriter("../../../Data/Locations.json");
            //FileReader fr = new FileReader();

            //Read from json to get locations list
            //List<Location> locations = fr.ReadLocations("../../../Data/Locations.json");

            //for testing will be in files will be replaced with reading from files
            List<Location> locations = new List<Location>();
            //test data 1
            Location chi = new Location("Chicago");
            chi.AddProduct(new Product(1, "Cyberpunk 9999", 100, 60.0));
            locations.Add(chi);

            //test data 2
            Location miami = new Location("Miami");
            miami.AddProduct(new Product(1, "Fallout 21", 15, 55.0));
            miami.AddProduct(new Product(2, "Borderlands 14", 100, 60.0));
            locations.Add(miami);

            CustomerDisplay cd = new CustomerDisplay();

            //Welcome user and get location to order from
            cd.DisplayWelcome();
            Console.WriteLine($"\nLocations:");
            while (runLocation)
            {
                //print all locations
                foreach (var city in locations)
                {
                    Console.WriteLine($"{city.LocationName}");
                }
                //get user location selection
                Console.Write($"\nSelect a Location: ");
                string locationInput = Console.ReadLine();
                bool containsItem = locations.Any(item => locationInput.Equals(item.LocationName, StringComparison.InvariantCultureIgnoreCase));
                if (containsItem == true)
                {
                    foreach(var city in locations)
                    {
                        if(locationInput.Equals(city.LocationName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            l = city;
                        }
                    }
                    runLocation = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid location please enter the location name again\n\nLocations:");
                }
            }
            //get user type and show corresponding store menus
            while(true)
            {
                Console.WriteLine("\nSelect User Type:\nCustomer (c)\nManager (m)\nQuit (q)");
                string userTypeInput = Console.ReadLine();

                if (userTypeInput.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    //create customer
                    var names = cd.DisplayNamesGet();
                    Customer c = new Customer($"{names.Item1}", $"{names.Item2}");

                    //shopping cart
                    ShoppingCart sc = new ShoppingCart();

                    //fix loop - wont let you select product if foreach already passed it
                    foreach (var item in l.Inventory)
                    {
                        string purchaseInput = "";
                        bool runPurchase = true;

                        while (runPurchase)
                        {
                            cd.DisplayStore(l); 
                            purchaseInput = Console.ReadLine();
                            if (purchaseInput.Equals(item.ProductName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                Console.Write("\nHow many would you like to buy (max 5): ");
                                string qtyInput = Console.ReadLine();
                                if(Int32.Parse(qtyInput) <= 5)
                                {
                                    sc.AddToCart(item, Int32.Parse(qtyInput));
                                    Console.WriteLine($"{qtyInput} of {item} added to cart");
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Input. Try Again.");
                                }
                            }
                            else if(purchaseInput.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                            {
                                bool checkout = cd.DisplayCart(sc);

                                //create and log order
                                if(checkout)
                                {
                                    Order o = new Order(l, c, DateTime.Now, sc.Cart);
                                    cd.DisplayCheckout(o, l);
                                }
                                else
                                {
                                    break;
                                }

                                //update locations inventory
                            }
                            else if (purchaseInput.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                            {
                                runPurchase = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid product try again or q to quit");
                            }
                        }
                    }
                }
                else if (userTypeInput.Equals("m", StringComparison.InvariantCultureIgnoreCase))
                {
                    ManagerDisplay md = new ManagerDisplay();
                }
                else if (userTypeInput.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.Write("Try again: ");
                }
            }
            Console.WriteLine("Thank You For Using Stream Game Store!");
        }
    }
}
