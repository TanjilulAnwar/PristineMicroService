using CatalogService.Commands.Inerfaces;
using CatalogService.Database;
using CatalogService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Commands.Handlers
{
    public class ProductCommand : IProductCommand
    {

        DatabaseContext _db;
        public ProductCommand(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<ProductModel> AddProductAsync(ProductModel model)
        {
            try
            {
                Product product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    UnitPrice = model.UnitPrice
                };
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                model.ProductId = product.ProductId;
                return model;
            }

            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            Product product = await _db.Products.FindAsync(Id);
            if(product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpsertProductAsync(ProductModel model)
        {
            try
            {
                Product product = new Product()
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Description = model.Description,
                    UnitPrice = model.UnitPrice
                };
                _db.Products.Update(product);
                await _db.SaveChangesAsync();

              
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
