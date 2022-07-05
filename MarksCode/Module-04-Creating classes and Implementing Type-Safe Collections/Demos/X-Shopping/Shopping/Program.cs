using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    class Program
    {
        static System.Collections.ArrayList cart = new System.Collections.ArrayList();

        static void Main(string[] args)
        {
            Book b = new Book();
            if(b is IShoppingCartItem)


            AddToShoppingCart(b);
        }


        //Key point. We do not need to change the code in this function as
        //new types of products become avaiable.
        static void AddToShoppingCart(IShoppingCartItem item)
        {
            cart.Add(item.GetDescription() + ", " + item.GetPrice());
        }
    }
}
