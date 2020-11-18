using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLibrary;

namespace Project0.ConsoleApp
{
    public class ManagerDisplay
    {
        public ManagerDisplay() { }

        /// <summary>
        /// Method to show manager menu options and run each option
        /// </summary>
        /// <param name="repo">The repo object to use repo methods</param>
        /// <param name="locations">a list of all the store locations from db</param>
        public void ShowManagerMenu(StoreRepository repo, List<StoreLocation> locations)
        {
            bool runMenu = true;

            while(runMenu)
            {
                //show menu options
                Console.WriteLine("\nManager Menu:");
                Console.WriteLine("1) Search Customer");
                Console.WriteLine("2) Display All Orders by Location");
                Console.WriteLine("3) Display All Orders by Customer");
                Console.WriteLine("4) Display An Orders Details");
                Console.Write("Enter a menu number or (q) to quit: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Customer search
                        Console.Write("\nEnter customers first name: ");
                        string first = Console.ReadLine();
                        Console.Write("Enter customers last name: ");
                        string last = Console.ReadLine();

                        Customer cust = repo.GetCustomerByName(first, last);

                        //print customers
                        if(cust == null)
                        {
                            Console.WriteLine("Customer not found in database");
                        }
                        else
                        {
                            Console.WriteLine("ID\tFIRST NAME\tLAST NAME\tUSER TYPE");
                            Console.WriteLine($"{cust.CustomerId}\t{cust.FirstName}\t\t{cust.LastName}\t\t{cust.UserType}");
                        }
                        break;
                    case "2": //All orders from location
                        //print locations
                        Console.WriteLine("\nLocations to search from: ");
                        foreach(var l in locations)
                        {
                            Console.WriteLine(l.StoreLocationName);
                        }

                        //get location and print out its orders
                        Console.Write("Search Location: ");
                        string locationInput = Console.ReadLine();
                        foreach (var x in locations)
                        {
                            if (locationInput.Equals(x.StoreLocationName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                List<Order> orderListLocation = (List<Order>)repo.GetOrdersByLocation(x);
                                Console.WriteLine("\nID\tSTORE ID\tCUSTOMER ID\tDATETIME\t\tTOTAL");
                                foreach (var o in orderListLocation)
                                {
                                    Console.WriteLine($"{o.OrderId}\t{o.OrderStoreLocationId}\t\t{o.OrderCustomerId}\t\t{o.OrderTime}\t${o.OrderTotal}");
                                }
                            }
                        }
                        break;
                    case "3": //All orders from user
                        //Customer search
                        Console.Write("\nEnter customers first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter customers last name: ");
                        string lastName = Console.ReadLine();
                        Customer c = repo.GetCustomerByName(firstName, lastName);

                        //get customers orders and print
                        List<Order> orderListCustomer = (List<Order>)repo.GetOrdersByCustomer(c);
                        Console.WriteLine("\nID\tSTORE ID\tCUSTOMER ID\tDATETIME\t\tTOTAL");
                        foreach (var o in orderListCustomer)
                        {
                            Console.WriteLine($"{o.OrderId}\t{o.OrderStoreLocationId}\t\t{o.OrderCustomerId}\t\t{o.OrderTime}\t${o.OrderTotal}");
                        }
                        break;
                    case "4": //display order items from order number
                        //Get order products
                        Console.Write("\nEnter the order id: ");
                        string orderId = Console.ReadLine();
                        List<Product> productList = (List<Product>)repo.GetOrderDetails(Int32.Parse(orderId));
                        //print products
                        if(productList.Count == 0)
                        {
                            Console.WriteLine("Order could not be found.");
                        }
                        else
                        {
                            string header = string.Format("\n{0,-5} {1,-20} {2,-6} {3,-3}  {4,-6}", "ID", "NAME", "PRICE", "QTY", "TOTAL");
                            Console.WriteLine(header);
                            foreach (var p in productList)
                            {
                                string output = string.Format("{0,-5} {1,-20} ${2,-6} {3,-3} ${4,-6}", p.ProductId, p.ProductName, p.ProductPrice, p.ProductQty, p.ProductPrice * p.ProductQty);
                                //Console.WriteLine($"{p.ProductId}\t{p.ProductName}\t\t${p.ProductPrice}\t(x{p.ProductQty})\t${p.ProductPrice * p.ProductQty}");
                                Console.WriteLine(output);
                            }
                        }
                        break;
                    case "q":
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a number 1-4 for which menu option you want or (q) to quit.");
                        break;
                }
            }
        }
    }
}
