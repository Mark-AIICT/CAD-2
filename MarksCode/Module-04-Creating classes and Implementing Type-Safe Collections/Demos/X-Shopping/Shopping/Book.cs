using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    public class Book : IShoppingCartItem, ITown
    {
         string ITown.GetDescription()
        {
            return "Lithgow";
        }

         string IShoppingCartItem.GetDescription()
        {
            return "Lord of rings";
        }

         decimal IShoppingCartItem.GetPrice()
        {
            return 300M;
        }
    }
}
