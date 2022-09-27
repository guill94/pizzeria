using Microsoft.EntityFrameworkCore;
using pizzeria.Data.Interfaces;
using pizzeria.Models;
using pizzeria.Data.ViewModels;

namespace pizzeria.Data
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;


        public ProductsRepository(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> data = await _context.Products.Include(p => p.IdCategoryNavigation).ToListAsync();
            return data;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product data = await _context.Products
                                .Include(i => i.IdIngredients)
                                .Include(c => c.IdCategoryNavigation)
                                .FirstOrDefaultAsync(n => n.IdProduct == id);

            return data;
        }


        public async Task CreateProduct(ProductVM product)
        {
            string rootPath = _webHost.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.ProductImageFile.FileName);
            string extension = Path.GetExtension(product.ProductImageFile.FileName);

            product.ProductImageName = fileName = fileName + DateTime.Now.ToString("yyMMddhhmmssfff") + extension;
            string path = Path.Combine(rootPath + "/images/" + fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ProductImageFile.CopyToAsync(fileStream);
            }


            List<Ingredient> IngList = new List<Ingredient>();
            foreach (int ingredientId in product.IdIngredients)
            {
                Ingredient ingredientBDD = await _context.Ingredients.FirstOrDefaultAsync(n => n.IdIngredient == ingredientId);  
                IngList.Add(ingredientBDD);
            }
            var newProduct = new Product()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductImageName = fileName,
                IdCategory = product.IdCategory,
                IdIngredients = IngList,

            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Ajout Ingredients
            /*foreach (var ingredientId in product.IdIngredients)
            {
                var newProductIngredient = new Pizza_Ingredient()
                {
                    PizzaId = newPizza.Id,
                    IngredientId = ingredientId,
                };
                await _context.Pizzas_Ingredients.AddAsync(newPizzaIngredient);

            }
            await _context.SaveChangesAsync();*/
        }

        public Task UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {
            Product data = await _context.Products.FirstOrDefaultAsync(n => n.IdProduct == id);
            if (data != null)
            {
                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        

        
    }
}
