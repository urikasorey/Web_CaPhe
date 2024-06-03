using Web_CaPhee2_api.Data;
using Web_CaPhee2_api.Models.Interface;

namespace Web_CaPhee2_api.Models.Services
{
    public class ProductRepository:IProductRepository
    {
        
private CoffeeshopApiDbContext dbContext;
        public ProductRepository(CoffeeshopApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }
        public Product GetProductDetail(int id)
        { 
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
    }
}
