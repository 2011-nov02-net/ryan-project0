using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace ProjectZero.BusinessLibrary
{
    /// <summary>
    /// FileReader Class
    /// Contains all the methods and fields for reading the json data files
    /// </summary>
    public class FileReader
    {
        //read locations json
        //read orders json

        public FileReader() { }
        
        public List<Location> ReadLocations(string filePath)
        {
            return null;
        }

        public List<Order> ReadOrders(string path)
        {
            List<Order> orderList = new List<Order>();
            /*
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                orderList = (List<Order>)serializer.Deserialize(file, typeof(List<Order>));
                
            }*/

            return orderList;
        }
    }
}
