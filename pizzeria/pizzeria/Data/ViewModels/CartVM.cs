using pizzeria.Data.Cart;
using System.Collections.Generic;

namespace pizzeria.Data.ViewModels
{
    public class CartVM
    {
        public ShoppingCart Cart { get; set; }

        public decimal CartTotal { get; set; }
    }
}
