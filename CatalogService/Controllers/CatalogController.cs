using CatalogService.Commands.Inerfaces;
using CatalogService.Database;
using CatalogService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProductCommand _productCommand;

        public CatalogController(IProductCommand productCommand)
        {
            _productCommand = productCommand;
        }

        //[HttpGet]
        //public  IEnumerable<Product> Get()
        //{
        //    return _db.Products.ToList();
        //}

        //GET:api/catalog/5
        //[HttpGet("{id}" , Name ="Get")]
        //public async Task<Product> Get(int id)
        //{
        //    return await _db.Products.FindAsync(id);
        //}


        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            try
            {
                var product = await _productCommand.AddProductAsync(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductModel model)
        {
            try
            {
                var updateSuccess = await _productCommand.UpsertProductAsync(model);
                if (updateSuccess)
                    return StatusCode(StatusCodes.Status200OK);
                return StatusCode(StatusCodes.Status304NotModified);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var deleteSuccess = await _productCommand.DeleteProductAsync(Id);
                if (deleteSuccess)
                    return StatusCode(StatusCodes.Status200OK);
                return StatusCode(StatusCodes.Status304NotModified);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return "Hello boss";
        }

    }
}
