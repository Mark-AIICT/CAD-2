using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    public interface IShoppingCartItem
    {
        string GetDescription();
        Decimal GetPrice();
    }

    public interface ITown
    {
        string GetDescription();
    }
}
