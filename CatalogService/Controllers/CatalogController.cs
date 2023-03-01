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

        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

    }
}
