using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }


        //Navigational Properties
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
