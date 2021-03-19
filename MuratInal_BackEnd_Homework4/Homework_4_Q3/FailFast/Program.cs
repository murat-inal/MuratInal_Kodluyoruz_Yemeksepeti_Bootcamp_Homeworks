using System;
using System.Collections.Generic;

namespace FailFast
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

            AddUser(user1);

        }

        public static List<User> AddUser(User user)
        {
            List<User> users = new List<User>();

            bool isUserIdValid = user.Id >= 0;
            bool isUserNameValid = string.IsNullOrWhiteSpace(user.Name);
            bool isUserSurnameValid = string.IsNullOrWhiteSpace(user.Surname);

            if (!isUserIdValid)
            {
                throw new ArgumentOutOfRangeException("ID is out of range");
            }
            if (!isUserNameValid)
            {
                throw new ArgumentNullException("Name must be filled!");
            }
            if (!isUserSurnameValid)
            {
                throw new ArgumentNullException("Surname must be filled!");
            }

            users.Add(user);
            return users;
        }
    }            
}