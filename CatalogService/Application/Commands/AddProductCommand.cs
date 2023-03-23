using CatalogService.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands
{
    public class AddProductCommand : ProductModel ,IRequest<ProductModel>
    {
    }
}
