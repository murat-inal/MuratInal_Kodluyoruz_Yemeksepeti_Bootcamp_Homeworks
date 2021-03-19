using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Homework_4_Q5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _productService.GetByName(name);

            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost("Add")]
        public void Post([FromBody]Product product)
        {
            _productService.Add(product);
        }

        [HttpPut("Update")]
        public void Update([FromBody] Product product)
        {
            _productService.Update(product);
        }

        [HttpDelete("Delete")]
        public void Delete([FromBody] Product product)
        {
            _productService.Delete(product);
        }
    }
}
