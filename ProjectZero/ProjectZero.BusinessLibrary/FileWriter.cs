using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ProjectZero.BusinessLibrary
{
    /// <summary>
    /// FileWriter Class
    /// Contains all the methods and fields for writing the json data files and saving data
    /// </summary>
    public class FileWriter
    {
        public FileWriter() { }

        //write locations json
        public void WriteLocationJson(List<Location> l, string path)
        {
            /*
            string json = JsonSerializer.Serialize(l, new JsonSerializerOptions { WriteIndented = true });

            using (var writer = new StreamWriter(path))
            {
                writer.Write(json);
            }*/
        }

        //write orders json
        public void WriteOrder(Order o, string path)
        {
            //get all orders
            List<Order> orderList = new List<Order>();
            foreach(var x in o.GetOrderList())
            {
                orderList.Add(x);
            }

            //add new order
            orderList.Add(o);

            //remake file with new order
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, orderList);
            }
        }
    }
}
