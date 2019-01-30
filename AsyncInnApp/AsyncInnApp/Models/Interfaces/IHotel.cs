using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IHotel
    {
        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotels();

        Task UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);

    }
}
