using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Homework_4_Q5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();

            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);

            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _categoryService.GetByName(name);

            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost("Add")]
        public void Post([FromBody] Category category)
        {
            _categoryService.Add(category);
        }

        [HttpPut("Update")]
        public void Update([FromBody] Category category)
        {
            _categoryService.Update(category);
        }

        [HttpDelete("Delete")]
        public void Delete([FromBody] Category category)
        {
            _categoryService.Delete(category);
        }
    }
}
