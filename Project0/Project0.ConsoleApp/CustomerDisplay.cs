using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project0.BusinessLibrary;

//SQL to check if name combo is in db and get id or create new customer and id
//Input validation on name so cant input numbers etc

namespace Project0.ConsoleApp
{
    public class CustomerDisplay
    {
        public CustomerDisplay() { }

        public Customer Login()
        {
            Customer c;
            string firstName = "";
            string lastName = "";

            Console.WriteLine("\nWelcome to STREAM Game Store!");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\nOPTIONS:\n(c) : Customer\n(m) : Manager\n(q) : Quit Program");
            Console.Write("Select User Type: ");
            string input = Console.ReadLine();

            if (input.Equals("c", StringComparison.InvariantCultureIgnoreCase))
            {
                //Create customer
                Console.Write("\nPlease enter your first name: ");
                firstName = Console.ReadLine();
                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

                c = new Customer(1, firstName, lastName, 1);
                return c;
            }
            else if(input.Equals("m", StringComparison.InvariantCultureIgnoreCase))
            {
                //Create manager
                Console.Write("\nPlease enter your first name: ");
                firstName = Console.ReadLine();
                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

                c = new Customer(1, firstName, lastName, 2);
                return c;
            }
            else if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nInvalid Input! Enter Selection Again!");
            }

            return new Customer(1, firstName, lastName, 1);
        }

        public StoreLocation GetStoreLocation(List<StoreLocation> locations)
        {
            StoreLocation store = null;
            Console.WriteLine("\nStore Locations:");
            foreach(var l in locations)
            {
                Console.WriteLine(l.StoreLocationName);
            }

            Console.Write("Location Selection: ");
            string input = Console.ReadLine();

            foreach(var x in locations)
            {
                if (input.Equals(x.StoreLocationName, StringComparison.InvariantCultureIgnoreCase))
                {
                    store = x;
                }
            }

            return store;
        }

        public void OpenShopping(StoreLocation l, Customer c, List<Product> p, StoreRepository repo)
        {
            bool runShopping = true;
            List<BusinessLibrary.Product> cart = new List<Product>();
            
            //list off all the products
            Console.WriteLine($"\n{l.StoreLocationName}'s Products List: ");
            foreach(var item in p)
            {
                Console.WriteLine($"{item.ProductName} ({item.ProductQty}) : ${item.ProductPrice}");
            }

            //get users product choice and add it to cart to purchase
            while(runShopping)
            {
                Console.WriteLine("\nSelect Item to Add to Cart or (q) to quit cart: ");
                string input = Console.ReadLine();
                foreach(var x in p)
                {
                    if(input.Equals(x.ProductName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.Write("How many would you like to add to cart (max 5): ");
                        string qtyInput = Console.ReadLine();
                        if(Int32.Parse(qtyInput) > 5)
                        {
                            Console.WriteLine("Too many to add to cart! Max is 5! Try Again.");
                        }
                        else
                        {
                            Console.WriteLine($"Added {qtyInput} of {x.ProductName} to cart.");
                            Product cartProduct = new Product(x.ProductId, x.ProductName, x.ProductPrice, Int32.Parse(qtyInput));
                            cart.Add(cartProduct);
                        }
                    }
                    else if(input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if(cart.Count() > 0) //cart not empty
                        {
                            Console.WriteLine("\nWould you like to checkout (y/n): ");
                            string checkoutInput = Console.ReadLine();

                            if(checkoutInput.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //begin checkout
                                //Display all of products in cart
                                string name = c.FirstName.ToLower();
                                double total = 0;
                                Console.WriteLine($"\n{char.ToUpper(name[0]) + name.Substring(1)}'s Cart\n--------------------");
                                foreach(var i in cart)
                                {
                                    Console.WriteLine($"{i.ProductName} x {i.ProductQty} : ${i.ProductPrice * i.ProductQty}");
                                    total += i.ProductPrice * i.ProductQty;
                                }
                                Console.WriteLine($"--------------------\nGrand Total: ${total}");
                                Console.WriteLine("\nWould you like to complete checkout (y/n): ");
                                string completeInput = Console.ReadLine();
                                if (completeInput.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    //create order and update table values
                                    Order o = new Order(c, DateTime.Now, l);
                                    repo.CreateOrder(o, total);
                                    repo.CreateOrderProduct(o, cart);

                                    Console.WriteLine("\nOrder Completed!");
                                    runShopping = false;
                                    break;                                    
                                }
                                else
                                {
                                    
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else //cart empty
                        {
                            runShopping = false;
                        }
                    }
                }
            }
        }
    }
}
