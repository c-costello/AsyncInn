using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Create a Room
        /// </summary>
        /// <param name="room">Room</param>
        /// <returns>Task</returns>
        Task CreateRoom(Room room);

        /// <summary>
        /// Get a Room by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        Task<Room> GetRoom(int id);

        /// <summary>
        /// Get All Rooms
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        Task<IEnumerable<Room>> GetRooms();

        /// <summary>
        /// Update a Room
        /// </summary>
        /// <param name="room">Room</param>
        /// <returns>Task</returns>
        Task UpdateRoom(Room room);
        
        /// <summary>
        /// Delete a Room by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        Task DeleteRoom(int id);
    }
}
