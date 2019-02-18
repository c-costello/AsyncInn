using AsyncInnApp.Data;
using AsyncInnApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class RoomService : IRoom
    {

        private AsyncInnDbContext _context { get; }

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a Room
        /// </summary>
        /// <param name="room">Room</param>
        /// <returns>Task</returns>
        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Get a Room by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(r => r.ID == id);
        }

        /// <summary>
        /// Get All Rooms
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Room.ToListAsync();
        }


        /// <summary>
        /// Update a Room
        /// </summary>
        /// <param name="room">Room</param>
        /// <returns>Task</returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a Room by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task DeleteRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(r => r.ID == id);
            IEnumerable<HotelRoom> hotelRoom = _context.HotelRoom.Where(h => h.RoomID == room.ID);
            IEnumerable<RoomAmenities> roomAmentites = _context.RoomAmenities.Where(h => h.RoomID == room.ID);
            foreach (var hotelroom in hotelRoom)
            {
                _context.HotelRoom.Remove(hotelroom);
            }
            foreach (var amenity in roomAmentites)
            {
                _context.RoomAmenities.Remove(amenity);
            }
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
