using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IAmenities
    {
        Task CreateAmenity(Amenities amenity);

        Task<Amenities> GetAmenity(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        Task UpdateAmenity(Amenities amenity);

        Task DeleteAmenity(int id);

    }
}
