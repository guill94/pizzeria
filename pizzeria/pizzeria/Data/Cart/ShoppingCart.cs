using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzeria.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string CartId { get; set; }

        public List<CartItem> CartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { CartId = cartId };
        }

        public void AddItemToCart(Product product)
        {
            var cartItem = _context.CarItems.FirstOrDefault(n => n.IdProductNavigation.IdProduct == product.IdProduct && n.CartId == CartId);

            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    CartId = CartId,
                    IdProductNavigation = product,
                    Amount = 1
                };

                _context.CarItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount ++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var cartItem = _context.CarItems.FirstOrDefault(n => n.IdProductNavigation.IdProduct == product.IdProduct && n.CartId == CartId);

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                }
                else
                {
                    _context.CarItems.Remove(cartItem);
                }
                
            }
            
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
            {
                return CartItems ?? (CartItems = _context.CarItems.Where(n => n.CartId == CartId).Include(n => n.IdProductNavigation).ToList());
            }

        public decimal GetCartTotal()
            {
                var total = _context.CarItems.Where(n => n.CartId == CartId).Select(n => n.IdProductNavigation.ProductPrice * n.Amount).Sum();

                return total;
            }

        public async Task ClearCart()
        {
            var items = await _context.CarItems.Where(n => n.CartId == CartId).ToListAsync();
            _context.CarItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
