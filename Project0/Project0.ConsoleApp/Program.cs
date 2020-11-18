using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project0.BusinessLibrary;
using Project0.Entity.Entities;

namespace Project0.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Main fucntion to create objects and run display menus
        /// </summary>
        static void Main(string[] args)
        {
            //Objects
            Customer c;
            BusinessLibrary.StoreLocation store;
            CustomerDisplay cd = new CustomerDisplay();

            //create repo object
            StoreRepository repo = new StoreRepository(CreateDbContext(), CreateDbContext(), CreateDbContext());
            while(true)
            {
                //get locations from db
                List<BusinessLibrary.StoreLocation> locations = new List<BusinessLibrary.StoreLocation>();
                locations = (List<BusinessLibrary.StoreLocation>)repo.GetStoreLocations();

                //Welcome and get user info
                c = cd.Login(repo, locations);

                //Get store location to purchase from
                store = cd.GetStoreLocation(locations);

                //Browse products from store and purchase
                cd.OpenShopping(store, c, (List<BusinessLibrary.Product>)repo.GetStoreInventory(store), repo);
            }
        }

        /// <summary>
        /// Method to create a db context
        /// </summary>
        static project0Context CreateDbContext()
        {
            //create log
            //using var logStream = new StreamWriter("project0-logs.txt");

            //context options
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            //optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information); //enable logging

            return new project0Context(optionsBuilder.Options);
        }

        /// <summary>
        /// Method to get get the connection string
        /// </summary>
        static string GetConnectionString()
        {
            string path = "../../../connection.json";
            string json = "";
            try
            {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading connection string");
                throw;
            }

            return json;
        }
    }
}
