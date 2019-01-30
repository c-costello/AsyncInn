using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    interface IHotel
    {
        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotels();

        void UpdateHotel(Hotel hotel);

        void DeleteHotel(int id);

    }
}
