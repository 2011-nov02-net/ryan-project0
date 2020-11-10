using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    interface IProduct
    {
        int ProductID { get; }
        string ProductName { get; }
        int ProductQty { get; set; }
        double ProductPrice { get; }
    }
}
