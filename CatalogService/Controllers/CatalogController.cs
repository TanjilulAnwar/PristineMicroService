using CatalogService.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        DatabaseContext _db;
        public CatalogController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.Products.ToList();
        }

        //GET:api/catalog/5
        [HttpGet("{id}" , Name ="Get")]
        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        //POST:api/catalog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, product);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
