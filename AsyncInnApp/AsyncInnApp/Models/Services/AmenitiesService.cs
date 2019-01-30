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
        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }


        public async Task<Amenities> GetAmenity(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }


        public void UpdateAmenity(Amenities amenity)
        {
            _context.Amenities.Update(amenity);
        }
        public void DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(a => a.ID == id);
            _context.Amenities.Remove(amenity);
            _context.SaveChanges();
        }
    }
}
