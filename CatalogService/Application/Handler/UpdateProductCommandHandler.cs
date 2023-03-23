using CatalogService.Application.Commands;
using CatalogService.Database;
using CatalogService.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductModel>
    {
        private readonly DatabaseContext _db;
        public UpdateProductCommandHandler(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = new Product()
                {
                    ProductId = request.ProductId,
                    Name = request.Name,
                    Description = request.Description,
                    UnitPrice = request.UnitPrice
                };
                _db.Products.Update(product);
                await _db.SaveChangesAsync();


                return request;
            }

            catch (Exception ex)
            {
                return request;
            }
        }
    }
}
