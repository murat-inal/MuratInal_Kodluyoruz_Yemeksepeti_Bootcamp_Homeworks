using System;
using System.Collections.Generic;

namespace ExtractMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<User> users = new List<User>();
            User user1 = new User
            {
                Id = 1,
                Name = "Murat",
                Surname = "İnal"
            };

            /* ----------- Wrong Usage -----------------
            foreach (var user in users)
            {
                if (user.Id >= 0)
                {
                    if (string.IsNullOrWhiteSpace(user.Name))
                    {
                        if (string.IsNullOrWhiteSpace(user.Surname))
                        {
                            users.Add(user);
                        }
                    }
                }
            }*/

            AddUser(user1);

        }

        public static List<User> AddUser(User user)
        {
            List<User> users = new List<User>();

            bool isUserIdValid = user.Id >= 0;
            bool isUserNameValid = string.IsNullOrWhiteSpace(user.Name);
            bool isUserSurnameValid = string.IsNullOrWhiteSpace(user.Surname);
            
            if (isUserIdValid)
            {
                if (isUserNameValid)
                {
                    if (isUserSurnameValid)
                    {
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
