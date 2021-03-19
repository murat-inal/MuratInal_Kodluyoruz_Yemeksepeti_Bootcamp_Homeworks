using Homework_4_Q4.Data;
using Homework_4_Q4.Data.Abstract;
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
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        ///  Get all students.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var result = _studentService.GetAll();

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
            var result = _studentService.GetById(id);

            if (result.StudentId > 0)
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
        public void Post([FromBody] Student student)
        {
            _studentService.Add(student);
        }

        /// <summary>
        /// Delete an existing teacher whose informations are given in body.
        /// </summary>
        /// <param name="teacher"></param>
        [HttpDelete("Delete")]
        public void Delete([FromBody] Student student)
        {
            _studentService.Delete(student);
        }

        /// <summary>
        /// Update an existing teacher whose informations are given in body.
        /// </summary>
        /// <param name="teacher"></param>
        [HttpPut("Update")]
        public void Update([FromBody] Student student)
        {
            _studentService.Update(student);
        }

    }
}
