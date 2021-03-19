using Microsoft.AspNetCore.Mvc;
using UserRegistration.Data.Entity;
using UserRegistration.RequestModel;

namespace UserRegistration.Interface
{
    public interface ISignUp
    {
        IActionResult Get();
        User GetByUserName(string userName);
        IActionResult Post([FromBody] UserRequest request);
    }
}
