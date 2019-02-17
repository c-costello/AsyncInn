using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IAmenities
    {
        /// <summary>
        /// Create a New Amenity
        /// </summary>
        /// <param name="amenity">Amenities</param>
        /// <returns>Task</returns>
        Task CreateAmenity(Amenities amenity);

        /// <summary>
        /// Get an Amenity by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        Task<Amenities> GetAmenity(int id);

        /// <summary>
        /// Get all Amentities
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        Task<IEnumerable<Amenities>> GetAmenities();

        /// <summary>
        /// Update an Ameitiy
        /// </summary>
        /// <param name="amenity">Amenities</param>
        /// <returns>Task</returns>
        Task UpdateAmenity(Amenities amenity);

        /// <summary>
        /// Delete an Amentiy by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        Task DeleteAmenity(int id);

    }
}
