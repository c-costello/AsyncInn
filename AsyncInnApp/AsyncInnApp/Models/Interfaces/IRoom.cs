using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    interface IRoom
    {
        Task CreateRoom(Room room);

        Task<Room> GetRoom(int id);

        Task<IEnumerable<Room>> GetRooms();

        void UpdateRoom(Room room);

        void DeleteRoom(int id);
    }
}
