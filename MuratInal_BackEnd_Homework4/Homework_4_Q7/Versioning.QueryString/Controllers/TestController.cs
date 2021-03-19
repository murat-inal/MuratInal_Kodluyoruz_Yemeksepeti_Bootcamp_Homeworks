using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Versioning.QueryString.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]

    public class TestController : ControllerBase
    {
        List<UserV1> usersV1 = new List<UserV1>()
        {
            new UserV1
            {
                Id=1,
                Name="Murat",
                Surname="İnal",
                Age=23
            },
            new UserV1
            {
                Id=2,
                Name="Merve",
                Surname="İnal",
                Age=26
            }
        };      

        
        [MapToApiVersion("2.0")]
        [HttpGet(Name =nameof(GetUsersV1))]
        public IActionResult GetUsersV1()
        {
            return Ok(usersV1);
        }

        [MapToApiVersion("3.0")]
        [HttpGet(Name = nameof(GetUsersV2))]
        public IActionResult GetUsersV2()
        {
            List<UserV2> usersV2 = new List<UserV2>();
            foreach (var user in usersV1)
            {
                usersV2.Add(new UserV2
                {
                    Id = user.Id,
                    FullName = string.Concat(user.Name, user.Surname),
                    Age = user.Age
                });
            }
            return Ok(usersV2);
        }
    }
}
