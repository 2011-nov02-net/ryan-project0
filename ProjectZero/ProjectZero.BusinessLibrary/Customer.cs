using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectZero.BusinessLibrary

{
    /// <summary>
    /// Customer Class
    /// Contains all the methods and fields for the customer objects
    /// </summary>
    public class Customer
    {
        //Maybe add default location

        //Fields
        [JsonPropertyName("first")]
        public string CustomerFirstName { get; }

        [JsonPropertyName("last")]
        public string CustomerLastName { get; }

        //Constructor
        public Customer(string custFirst, string custLast)
        {
            CustomerFirstName = custFirst;
            CustomerLastName = custLast;
        }
    }
}
