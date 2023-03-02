using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IBus _busService;
        private readonly IConfiguration _configuration;

        public CustomerProductController(IBus busService, IConfiguration configuration)
        {
            _busService = busService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<string> CreateProduct(CustomerProduct product)
        {
            if(product!= null)
            {
                product.AddedOnDate = DateTime.Now;
                Uri uri = new Uri(_configuration.GetValue<string>("ServiceBus:Uri"));
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(product);
                return "true";
               
            }
            return "false";
        }
        

    }
}
