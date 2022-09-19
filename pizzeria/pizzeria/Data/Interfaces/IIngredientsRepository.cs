using pizzeria.Models;

namespace pizzeria.Data.Interfaces
{
    public interface IIngredientsRepository
    {
        public Task<IEnumerable<Ingredient>> GetAllIngredients();

        public Task<Ingredient> GetIngredientById(int id);

        public Task CreateIngredient(Ingredient ingredient);

        public Task UpdateIngredient(int id, Ingredient ingredient);

        public Task DeleteIngredient(int id);
    }
}
