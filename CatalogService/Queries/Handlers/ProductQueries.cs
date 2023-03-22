using CatalogService.Database;
using CatalogService.Models;
using CatalogService.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Queries.Handlers
{
    public class ProductQueries : IProductQueries
    {
        DatabaseContext _db;
        public ProductQueries(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductModel> GetAllProduct()
        {
            try
            {
                return  _db.Products.Select(x=> new ProductModel() { 
                
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description= x.Description,
                    UnitPrice = x.UnitPrice
                
                
                }).AsEnumerable();
            }

            catch
            {
                throw new Exception();
            }
        }

        public async Task<ProductModel> GetProductAsync(int Id)
        {
            try
            {
               var prod =   await _db.Products.FindAsync(Id);
                return new ProductModel()
                {

                    ProductId = prod.ProductId,
                    Name = prod.Name,
                    Description = prod.Description,
                    UnitPrice = prod.UnitPrice


                };
            }

            catch
            {
                throw new Exception();
            }
        }
    }
}
