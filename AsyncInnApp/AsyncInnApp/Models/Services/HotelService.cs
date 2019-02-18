using AsyncInnApp.Data;
using AsyncInnApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context { get; }

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new Hotel
        /// </summary>
        /// <param name="hotel">Hotel</param>
        /// <returns>Task</returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Get Hotel by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task Hotel</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotel.FirstOrDefaultAsync(h => h.ID == id);
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotel.ToListAsync();
        }

        /// <summary>
        /// Update a Hotel
        /// </summary>
        /// <param name="hotel">Hotel</param>
        /// <returns>Task</returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Delete Hotel By ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotel.FirstOrDefault(h => h.ID == id);
            IEnumerable<HotelRoom> hotelRoom = _context.HotelRoom.Where(h => h.HotelID == hotel.ID);
            foreach (var room in hotelRoom)
            {
                _context.HotelRoom.Remove(room);
            }
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

    }
}
