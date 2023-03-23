using CatalogService.Models;
using MediatR;
using System.Collections.Generic;

namespace CatalogService.Application.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductModel>>
    {
    }
}
