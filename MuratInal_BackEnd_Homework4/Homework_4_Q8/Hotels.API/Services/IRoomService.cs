using Hotels.API.Models.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.API.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomsAsync();
        Task<Room> GetRoomAsync(Guid id);
    }
}
