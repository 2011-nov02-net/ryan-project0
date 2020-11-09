using System;
using System.Runtime.CompilerServices;

namespace ProjectZero.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BLANK Console Store Menu");
            Console.WriteLine("-------------------");
            Console.WriteLine($"\nSelect Location:");
            string locationInput = Console.ReadLine();
            while(true)
            {
                Console.WriteLine("\nSelect User Type:\nCustomer (c)\nManager (m)\nQuit (q)");
                string userTypeInput = Console.ReadLine();

                if (userTypeInput.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    CustomerDisplay cd = new CustomerDisplay();
                    cd.DisplayStore();
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
                    Console.WriteLine("Please select (c) for customer or (m) for manager or (q) to quit.");
                }
            }
            Console.WriteLine("Thank You For Using BLANK Console Store!");
        }
    }
}
