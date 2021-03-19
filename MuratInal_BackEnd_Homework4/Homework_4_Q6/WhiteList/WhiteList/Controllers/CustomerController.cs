using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        List<string> customers = new List<string>
        {
            "Murat İnal",
            "Merve İnal"
        };

        [HttpGet(Name =nameof(GetCustomers))]
        public IActionResult GetCustomers()
        {
            return Ok(customers);
        }
    }
}
