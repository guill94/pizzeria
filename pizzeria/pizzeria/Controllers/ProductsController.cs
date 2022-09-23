using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pizzeria.Data;
using pizzeria.Data.Interfaces;
using pizzeria.Data.ViewModels;
using pizzeria.Models;

namespace pizzeria.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsRepository _repo;

        public ProductsController(AppDbContext context, IProductsRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> data = await _repo.GetAllProducts();
            return View(data);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product data = await _repo.GetProductById(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdCategory"] = new SelectList(_context.Categories, "IdCategory", "IdCategory");
            ICollection<Ingredient> ingredients = await _context.Ingredients.OrderBy(n => n.IngredientName).ToListAsync();
            ViewData["IngredientIds"] = new SelectList(ingredients, "IdIngredient", "IngredientName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,ProductName,ProductDescription,ProductPrice,ProductImageFile,IdCategory, IdIngredients")] ProductVM product)
        {
            
            //if (ModelState.IsValid)
            //{
               await _repo.CreateProduct(product);
                //_context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ICollection<Ingredient> ingredients = await _context.Ingredients.OrderBy(n => n.IngredientName).ToListAsync();
            ViewData["IngredientIds"] = new SelectList(ingredients, "IdIngredient", "IngredientName");
            ViewBag.IngredientIds = new SelectList(ingredients, "IdIngredient", "IngredientName");
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["IdCategory"] = new SelectList(_context.Categories, "IdCategory", "IdCategory", product.IdCategory);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,ProductName,ProductDescription,ProductPrice,ProductImageName,IdCategory")] Product product)
        {
            if (id != product.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.IdProduct))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategory"] = new SelectList(_context.Categories, "IdCategory", "IdCategory", product.IdCategory);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.IdCategoryNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.IdProduct == id);
        }
    }
}
