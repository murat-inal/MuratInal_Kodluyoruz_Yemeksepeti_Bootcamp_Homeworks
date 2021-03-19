using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data.Context;
using UserRegistration.Data.Entity;

namespace UserRegistration
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new UsersDbContext(serviceProvider.GetRequiredService<DbContextOptions<UsersDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.AddRange(
                    new User
                    {
                        Id = 4,
                        UserName = "ali.veli",
                        Name = "Ali",
                        Surname = "Veli",
                        UserMail = "ali.veli@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 5,
                        UserName = "ayse.fatma",
                        Name = "Ayşe",
                        Surname = "Fatma",
                        UserMail = "ayse.fatma@gmail.com",
                        Password = "123456"
                    });

                context.SaveChanges();
            }
        }
    }
}
