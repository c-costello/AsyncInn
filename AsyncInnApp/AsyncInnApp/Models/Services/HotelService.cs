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
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotel.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotel.ToListAsync();
        }


        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotel.FirstOrDefault(h => h.ID == id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

    }
}
