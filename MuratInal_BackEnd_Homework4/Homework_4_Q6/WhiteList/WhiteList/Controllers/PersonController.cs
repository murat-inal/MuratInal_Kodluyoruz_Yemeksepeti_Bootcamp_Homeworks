using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<string> persons = new List<string>
        {
            "Murat",
            "Merve",
            "Eren"
        };

        [HttpGet(Name =nameof(GetPersons))]
        public IActionResult GetPersons()
        {
            return Ok(persons);
        }
    }
}
