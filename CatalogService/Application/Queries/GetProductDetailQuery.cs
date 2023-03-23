using CatalogService.Models;
using MediatR;

namespace CatalogService.Application.Queries
{
    public class GetProductDetailQuery : IRequest<ProductModel>
    {
        public int Id { get; set; }
    }
}
