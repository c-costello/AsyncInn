using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IHotel
    {

        /// <summary>
        /// Create a new Hotel
        /// </summary>
        /// <param name="hotel">Hotel</param>
        /// <returns>Task</returns>
        Task CreateHotel(Hotel hotel);

        /// <summary>
        /// Get Hotel by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task Hotel</returns>
        Task<Hotel> GetHotel(int id);

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns>Task IEnumerable</returns>
        Task<IEnumerable<Hotel>> GetHotels();

        /// <summary>
        /// Update a Hotel
        /// </summary>
        /// <param name="hotel">Hotel</param>
        /// <returns>Task</returns>
        Task UpdateHotel(Hotel hotel);

        /// <summary>
        /// Delete Hotel By ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        Task DeleteHotel(int id);


    }
}
