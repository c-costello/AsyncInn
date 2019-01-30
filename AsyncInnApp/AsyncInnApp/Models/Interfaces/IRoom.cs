using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IRoom
    {
        Task CreateRoom(Room room);

        Task<Room> GetRoom(int id);

        Task<IEnumerable<Room>> GetRooms();

        Task UpdateRoom(Room room);

        Task DeleteRoom(int id);
    }
}
