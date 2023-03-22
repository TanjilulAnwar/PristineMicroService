using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Commands.Inerfaces
{
    public interface IProductCommand
    {
        Task<ProductModel> AddProductAsync(ProductModel model);
        Task<bool> UpsertProductAsync(ProductModel model);
        Task<bool> DeleteProductAsync(int Id);
    }
}
