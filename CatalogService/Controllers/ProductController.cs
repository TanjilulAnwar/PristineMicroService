using CatalogService.Application.Commands;
using CatalogService.Application.Queries;
using CatalogService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator Mediator;

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        //ocelot gateway call
        //ocelot Base Url:http://localhost:49932
        /*
         * /catalog/api/product/getall
         * /catalog/api/product/get?Id=
         * /catalog/api/product/add
         * /catalog/api/product/update
         * /catalog/api/product/delete?id=
         */

        [HttpGet]
        public async Task<ActionResult<ProductModel>> Get(int Id)
        {
           return Ok(await Mediator.Send(new GetProductDetailQuery() { Id = Id }));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> Add(AddProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand() { Id = Id }));
        }


    }
}

