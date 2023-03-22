using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Queries.Interfaces
{
    public interface IProductQueries
    {
        IEnumerable<ProductModel> GetAllProduct();
        Task<ProductModel> GetProductAsync(int Id);
  
    }
}
