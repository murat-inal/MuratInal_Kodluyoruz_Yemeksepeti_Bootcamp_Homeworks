using AutoMapper;
using Hotels.API.Contexts;
using Hotels.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.API.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly HotelApiDbContext _dbContext;
        private IConfiguration _configuration;

        public UserService(HotelApiDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserInfo> Authenticate(TokenRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.LoginUser) || string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.LoginName == req.LoginUser &&
                                                                           user.Password == req.LoginPassword);

            if (user == null)
            {
                return null;
            }
                        
            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]

                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature),
                
            };

            var newToken = tokenHandler.CreateToken(tokenDesc);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.ExpireTime = tokenDesc.Expires ?? DateTime.UtcNow.AddHours(1);
            userInfo.Token = tokenHandler.WriteToken(newToken);
            userInfo.RefreshToken = CreateRefreshToken();

            return userInfo;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
