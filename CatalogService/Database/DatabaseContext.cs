using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) //base chaining
        {

        }
        public DbSet<Product> Products { get; set; }
    }

}
