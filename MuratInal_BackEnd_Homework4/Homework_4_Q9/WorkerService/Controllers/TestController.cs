using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkerService.Context;

namespace WorkerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly WorkerServiceDbContext _dbContext;

        public TestController(WorkerServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _dbContext.Users.ToList();
            return Ok(result);
        }
    }
}
