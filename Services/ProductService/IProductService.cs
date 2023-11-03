using TechTestAPI.Models;

namespace TechTestAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();        
        Task<List<Product>> Add(Product product);
        Task<List<Product>> Update(int id, Product product);
    }
}
