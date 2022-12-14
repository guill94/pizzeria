using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pizzeria.Data;
using pizzeria.Data.Interfaces;
using pizzeria.Models;

namespace pizzeria.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly AppDbContext _context;
        //private readonly IIngredientsRepository _repo;

        private readonly IngredientsRepository _repo;

        public IngredientsController(AppDbContext context, IngredientsRepository repo)
        {
            _context = context;
            _repo = repo;


        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            IEnumerable<Ingredient> data = await _repo.GetAllIngredients();
            return View(data);
        }

       

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngredient,IngredientName")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateIngredient(ingredient);
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            Ingredient ingredient = await _repo.GetIngredientById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngredient,IngredientName")] Ingredient ingredient)
        {
            if (id != ingredient.IdIngredient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IdIngredient))
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
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IdIngredient == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingredients == null)
            {
                return Problem("Entity set 'AppDbContext.Ingredients'  is null.");
            }
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
          return _context.Ingredients.Any(e => e.IdIngredient == id);
        }
    }
}
