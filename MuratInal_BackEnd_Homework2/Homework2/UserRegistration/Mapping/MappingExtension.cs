using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data.Context;
using UserRegistration.Data.Entity;

namespace UserRegistration.Mapping
{
    public static class MappingExtension
    {
        public static List<UserModel> ToUserResponse(this List<User> users)
        {
            List<UserModel> result = new List<UserModel>();

            foreach (var user in users)
            {
                result.Add(new UserModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    UserMail = user.UserMail,
                    //Password = user.Password
                });
            }

            return result;
        }
    }
}
