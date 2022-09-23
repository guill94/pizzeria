using pizzeria.Data.ViewModels;
using pizzeria.Models;

namespace pizzeria.Data.Interfaces
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<Product> GetProductById(int id);

        public Task CreateProduct(ProductVM product);

        public Task UpdateProduct(int id, Product product);

        public Task DeleteProduct(int id);
    }
}
