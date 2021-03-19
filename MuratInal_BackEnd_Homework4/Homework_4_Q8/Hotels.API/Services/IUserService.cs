using Hotels.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.API.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
    }
}
