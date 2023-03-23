using CatalogService.Application.Commands;
using CatalogService.Database;
using CatalogService.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Handler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductModel>
    {
        private readonly DatabaseContext _db;
        public AddProductCommandHandler(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    UnitPrice = request.UnitPrice
                };
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                request.ProductId = product.ProductId;
                return request;
            }

            catch
            {
                throw new Exception();
            }
        }
    }
}
