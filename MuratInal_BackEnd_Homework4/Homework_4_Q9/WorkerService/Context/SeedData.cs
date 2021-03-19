using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkerService.Entity;

namespace WorkerService.Context
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<WorkerServiceDbContext>());
        }

        public static async Task AddSampleData(WorkerServiceDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User
                {
                    Id = 1,
                    UserName = "muratinal",
                    LoginTime = DateTime.Now,
                    EndLoginTime = DateTime.Now.AddSeconds(5),
                    IsOnline = true
                });

                dbContext.Users.Add(new User
                {
                    Id = 2,
                    UserName = "Murat İnal",
                    LoginTime = DateTime.Now,
                    EndLoginTime = DateTime.Now.AddSeconds(25),
                    IsOnline = true
                });
            }

            await dbContext.SaveChangesAsync();

        }
    }
}
