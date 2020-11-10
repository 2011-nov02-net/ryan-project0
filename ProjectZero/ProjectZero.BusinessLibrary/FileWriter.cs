using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
            string json = JsonSerializer.Serialize(l, new JsonSerializerOptions { WriteIndented = true });

            using (var writer = new StreamWriter(path))
            {
                writer.Write(json);
            }
        }
        //write orders json
    }
}
