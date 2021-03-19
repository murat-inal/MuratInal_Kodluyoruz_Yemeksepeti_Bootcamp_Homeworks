using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        List<User> users = new List<User>();


        //[Route("Get")]
        [HttpGet(Name = nameof(Get))]
        public IActionResult Get()
        {
            User user = new User
            {
                Id = 1,
                Name = "Murat",
                Surname = "İnal"
            };
            users.Add(user);

            return Ok(users);
        }

        //[Route("Post")]
        [HttpPost(Name = nameof(Post))]
        public void Post([FromBody] User user)
        {
            users.Add(user);
        }
    }
}
