using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    interface IAmenities
    {
        Task CreateAmenity(Amenities amenity);

        Task<Amenities> GetAmenity(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        void UpdateAmenity(Amenities amenity);

        void DeleteAmenity(int id);

    }
}
