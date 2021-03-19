using System;
using System.Collections.Generic;
using System.Linq;

namespace ProperTool
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void DeleteUser(UserRequest req)
        {
            List<User> users = new List<User>();
            /* ----------------- Wrong Usage ---------------------------------------------
            foreach (var user in users) { 
                if (user.Id == req.Id && user.Name == req.Name && user.Surname == req.Surname)
                {
                    users.Remove(user);
                }
            }*/
            
            var userToDelete = users.FirstOrDefault(u => u.Id == req.Id && u.Name == req.Name && u.Surname == req.Surname);
            users.Remove(userToDelete);            
        }
    }
}
