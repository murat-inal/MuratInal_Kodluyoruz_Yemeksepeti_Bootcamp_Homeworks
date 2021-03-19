using Homework_4_Q4.Entity;
using Homework_4_Q4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        ///  Get all teachers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var result = _teacherService.GetAll();

            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Get the teacher whose id is equal to the id entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _teacherService.GetById(id);

            if (result.TeacherId > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Add new teacher which is given in body.
        /// </summary>
        /// <param name="teacher"></param>
        [HttpPost("Add")]
        public void Post([FromBody] Teacher teacher)
        {
            _teacherService.Add(teacher);
        }

        /// <summary>
        /// Delete an existing teacher whose informations are given in body.
        /// </summary>
        /// <param name="teacher"></param>
        [HttpDelete("Delete")]
        public void Delete([FromBody] Teacher teacher)
        {
            _teacherService.Delete(teacher);
        }

        /// <summary>
        /// Update an existing teacher whose informations are given in body.
        /// </summary>
        /// <param name="teacher"></param>
        [HttpPut("Update")]
        public void Update([FromBody] Teacher teacher)
        {
            _teacherService.Update(teacher);
        }
    }
}
