using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;

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
            string json;
            List<Location> readLocations = new List<Location>();

            try
            {
                json = File.ReadAllText(filePath);
            }
            catch (IOException)
            {
                return new List<Location>();
            }

            Location data = JsonSerializer.Deserialize<Location>(json); //broken
            readLocations.Add(data);

            return readLocations;
        }
    }
}
