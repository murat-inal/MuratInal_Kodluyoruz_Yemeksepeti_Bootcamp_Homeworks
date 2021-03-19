using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.API.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated =true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name =nameof(GetCustomers))]
        public IActionResult GetCustomers()
        {
            List<string> customers = new List<string>()
            {
                "Burak Karadağ",
                "Ece Karadağ"
            };
            return Ok(customers);
        }

        [HttpGet(Name =nameof(GetCustomerV2))]
        public IActionResult GetCustomerV2()
        {
            List<string> customers = new List<string>()
            {
                "Burak",
                "Ece"
            };
            return Ok(customers);
        }
    }
}
