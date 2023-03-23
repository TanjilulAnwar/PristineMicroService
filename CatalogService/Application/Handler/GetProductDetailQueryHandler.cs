using CatalogService.Application.Queries;
using CatalogService.Database;
using CatalogService.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Handler
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductModel>
    {
        private readonly DatabaseContext _db;
        public GetProductDetailQueryHandler(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<ProductModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prod = await _db.Products.FindAsync(request.Id);
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
