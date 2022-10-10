using Microsoft.EntityFrameworkCore;
using pizzeria.Data.Interfaces;
using pizzeria.Models;

namespace pizzeria.Data
{
    public class IngredientsRepository// : IIngredientsRepository
    {

        //private readonly AppDbContext _context;
        AppDbContext _context;
        public IngredientsRepository(/*AppDbContext context*/)
        {
            _context = new AppDbContext(); 
        }


        /// <summary>
        /// Retourne les ingrédients
        /// </summary>
        /// <returns>Liste des ingrédients</returns>
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            IEnumerable<Ingredient> data = await _context.Ingredients.ToListAsync();
            return data;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            var data = await _context.Ingredients.FindAsync(id);

            return data;
        }


        /// <summary>
        /// Creation d'un nouveau ingrédient
        /// </summary>
        /// <returns></returns>
        public async Task CreateIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Mise à jour ingrédient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public async Task UpdateIngredient(int id, Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Suppression ingrédient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteIngredient(int id)
        {
            var data = await _context.Ingredients.FirstOrDefaultAsync(n => n.IdIngredient == id);
            if (data != null)
            {
                _context.Ingredients.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
 
}
