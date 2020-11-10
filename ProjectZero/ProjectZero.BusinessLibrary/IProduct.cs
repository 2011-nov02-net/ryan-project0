using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    interface IProduct
    {
        int ProductID { get; }
        string ProductName { get; }
        int ProductInventory { get; set; }
        double ProductPrice { get; }
    }
}
