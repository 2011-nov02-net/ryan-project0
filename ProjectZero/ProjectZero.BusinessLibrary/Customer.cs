using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary

{
    /// <summary>
    /// Customer Class
    /// Contains all the methods and fields for the customer objects
    /// </summary>
    class Customer
    {
        //Maybe add default location

        //Fields
        public string CustomerFirstName { get; }
        public string CustomerLastName { get; }

        //Constructor
        public Customer(string custFirst, string custLast)
        {
            CustomerFirstName = custFirst;
            CustomerLastName = custLast;
        }
    }
}
