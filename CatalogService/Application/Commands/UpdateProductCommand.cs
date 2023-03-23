using CatalogService.Models;
using MediatR;

namespace CatalogService.Application.Commands
{
    public class UpdateProductCommand : ProductModel, IRequest<ProductModel>
    {
    }
}
