using AsyncInnApp.Data;
using AsyncInnApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        private AsyncInnDbContext _context { get; }

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a New Amenity
        /// </summary>
        /// <param name="amenity">Amenities</param>
        /// <returns>Task</returns>
        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get an Amenity by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task<Amenities> GetAmenity(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        /// <summary>
        /// Get all Amentities
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }


        /// <summary>
        /// Update an Ameitiy
        /// </summary>
        /// <param name="amenity">Amenities</param>
        /// <returns>Task</returns>
        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.Amenities.Update(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an Amentiy by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(a => a.ID == id);
            IEnumerable<RoomAmenities> roomAmenities = _context.RoomAmenities.Where(h => h.AmenitiesID == amenity.ID);
            foreach (var roomAmenity in roomAmenities)
            {
                _context.RoomAmenities.Remove(roomAmenity);
            }
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
