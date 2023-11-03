using Microsoft.EntityFrameworkCore;
using TechTestAPI.Models;

namespace TechTestAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base (options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<HistoryStock> HistoryStocks { get; set; }
    }
}
