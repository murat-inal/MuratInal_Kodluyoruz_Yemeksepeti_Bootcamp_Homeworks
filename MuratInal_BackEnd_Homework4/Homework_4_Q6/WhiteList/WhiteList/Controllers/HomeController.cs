using Microsoft.AspNetCore.Mvc;

namespace WhiteList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name =nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),

                Person = new
                {
                    href = Url.Link(nameof(PersonController.GetPersons), null)
                },

                Customer = new
                {
                    href = Url.Link(nameof(CustomerController.GetCustomers), null)
                }
            };

            return Ok(response);
        }
    }
}
