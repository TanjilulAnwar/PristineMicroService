using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

}
