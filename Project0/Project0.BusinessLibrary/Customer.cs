using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLibrary
{
    public class Customer
    {
        public int CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; private set; }
        public int UserType { get; private set; }

        public Customer(int id, string first, string last, int type)
        {
            CustomerId = id;
            FirstName = first;
            LastName = last;
            UserType = type;
        }
    }
}
