using CatalogService.Application.Queries;
using CatalogService.Database;
using CatalogService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Application.Handler
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductModel>>
    {

        private readonly DatabaseContext _db;
        public GetAllProductsQueryHandler(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _db.Products.Select(x => new ProductModel()
                {

                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                    UnitPrice = x.UnitPrice


                }).ToListAsync();
            }

            catch
            {
                throw new Exception();
            }
        }
    }
}
