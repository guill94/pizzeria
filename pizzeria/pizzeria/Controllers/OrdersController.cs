using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pizzeria.Data;
using pizzeria.Data.Cart;
using pizzeria.Data.Interfaces;
using pizzeria.Data.ViewModels;
using pizzeria.Models;
using System.Security.Claims;

namespace pizzeria.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsRepository _repoProd;
        private readonly IOrdersRepository _repoOrd;
        private readonly ShoppingCart _cart;
        private readonly AppDbContext _context;

        public OrdersController(IProductsRepository repoProd, IOrdersRepository repoOrd, AppDbContext context, ShoppingCart cart)
        {
            _repoOrd = repoOrd;
            _repoProd = repoProd;
            _context = context;
            _cart = cart;
        }



        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _repoOrd.GetOrderByUserId(userId);

            return View(orders);
        }


        public IActionResult ShoppingCart()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            var response = new CartVM()
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal(),
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToCart(int Id)
        {
            var item = await _repoProd.GetProductById(Id);

            if (item != null)
            {
                _cart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveItemFromCart(int Id)
        {
            var item = await _repoProd.GetProductById(Id);

            if (item != null)
            {
                _cart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var items = _cart.GetCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //string emailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _repoOrd.StoreOrder(items, userId);
            await _cart.ClearCart();

            return View("OrderCompleted");
        }

        public async Task<IActionResult> OrderOptions()
        {
            ViewData["addresses"] = new SelectList(await _context.Addresses.ToListAsync(), "IdAddress", "AddressesStreet");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderOptions([Bind("IdAddress")] Address address)
        {
            var items = _cart.GetCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _repoOrd.StoreOrder(items, userId, address.IdAddress);
            await _cart.ClearCart();

            return View("OrderCompleted");
        }
    }
}
