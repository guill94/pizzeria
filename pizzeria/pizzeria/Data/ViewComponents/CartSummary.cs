using Microsoft.AspNetCore.Mvc;
using pizzeria.Data.Cart;

namespace pizzeria.Data.ViewComponents
{
    
    public class CartSummary : ViewComponent
    {

        private readonly ShoppingCart _cart;

        public CartSummary(ShoppingCart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetCartItems();

            return View(items.Count);
        }
    }
}
