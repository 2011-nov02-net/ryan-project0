using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.BusinessLibrary
{
    public class ShoppingCart
    {
        public Dictionary<Product, int> Cart = new Dictionary<Product, int>();

        public ShoppingCart() { }

        public void AddToCart(Product p, int qty)
        {
            Cart.Add(p, qty);
        }

        public void RemoveFromCart(Product p)
        {
            Cart.Remove(p);
        }
    }
}
