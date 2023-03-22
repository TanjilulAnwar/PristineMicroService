﻿using CatalogService.Commands.Inerfaces;
using CatalogService.Database;
using CatalogService.Models;
using CatalogService.Queries.Interfaces;
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
        private IProductQueries _productQueries;
        public CatalogController(IProductCommand productCommand, IProductQueries productQueries)
        {
            _productCommand = productCommand;
            _productQueries = productQueries;
        }


        [HttpPost]
        public async Task<ActionResult> Add(ProductModel model)
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
        public async Task<ActionResult> Update(ProductModel model)
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
        public async Task<ActionResult> Delete(int Id)
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
        public async Task<ActionResult<ProductModel>> Get(int Id)
        {
            return await _productQueries.GetProductAsync(Id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            return Ok(_productQueries.GetAllProduct());
        } 

    }
}

//ocelot gateway call
//http://localhost:49932/catalog/api/Catalog/getall
