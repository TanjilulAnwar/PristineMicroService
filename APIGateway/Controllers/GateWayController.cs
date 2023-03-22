using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GateWayController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Start()
        {
            return "API GATEWAY";
        }
    }
}
