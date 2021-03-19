using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data.Context;
using UserRegistration.Data.Entity;
using UserRegistration.Interface;
using UserRegistration.Mapping;
using UserRegistration.RequestModel;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : ControllerBase, ISignUp
    {

        private readonly UsersDbContext _context;

        public SignUpController(UsersDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Get()
        {
            List<UserModel> result = new List<UserModel>();


            var entityList = _context.Users.ToList();
            result = entityList.ToUserResponse();

            return Ok(result);
        }

        [HttpGet("{userName}")]
        public User GetByUserName(string userName)
        {

            return _context.Users.FirstOrDefault(u => u.UserName == userName);

        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequest request)
        {
            var validation = request.Validate();

            if (validation.isNotValid)
            {
                return BadRequest(validation.errors);
            }
            else
            {
                _context.Users.Add(new User
                {
                    Id = request.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.UserName,
                    UserMail = request.UserMail,
                    Password = request.Password
                });
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
