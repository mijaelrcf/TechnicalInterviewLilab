using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TechTestAPI.Data;
using TechTestAPI.Models;

namespace TechTestAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<List<Product>> Add(Product product)
        {
            await _dataContext.Products.AddAsync(product);              

            await _dataContext.SaveChangesAsync();

            var id = product.Id;

            HistoryStock historyStock = new HistoryStock()
            {
                Date = DateTime.UtcNow,
                ProductId = id,
                Stock = 0
            };

            _dataContext.HistoryStocks.Add(historyStock);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Products.ToListAsync();
        }

        public async Task<List<Product>> Update(int id, Product request)
        {
            var product = await _dataContext.Products.FindAsync(id);

            if (product == null)
                return null;

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            HistoryStock historyStock = new HistoryStock()
            {
                Date = DateTime.UtcNow,
                ProductId = product.Id,
                Stock = product.Stock
            };

            _dataContext.HistoryStocks.Add(historyStock);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Products.ToListAsync();
        }
    }
}
