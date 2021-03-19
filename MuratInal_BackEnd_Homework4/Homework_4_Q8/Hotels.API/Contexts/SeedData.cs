using Hotels.API.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.API.Contexts
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddSampleData(HotelApiDbContext dbContext)
        {
            if (!dbContext.Rooms.Any())
            {



                dbContext.Rooms.Add(new RoomEntity
                {
                    Id = Guid.Parse("abdd6a7b-4f9a-4afb-9141-127b4d6bd7a2"),
                    Name = "Standart Oda",
                    Rate = 34524,
                    IsMigrate = false
                });

                dbContext.Rooms.Add(new RoomEntity
                {
                    Id = Guid.Parse("d283bf6b-883b-45b1-972a-6b55f2ee5ec1"),
                    Name = "Suit Oda",
                    Rate = 34524,
                    IsMigrate = false
                });
            }

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new UserEntity
                {
                    Id = 1,
                    Name = "Burak",
                    LastName = "Karadağ",
                    LoginName = "HBK",
                    Password = "1234",
                    Phone = "05555555555"
                });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
