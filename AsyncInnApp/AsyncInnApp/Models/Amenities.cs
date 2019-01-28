using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }
        

        //Navigational Properties
        public RoomAmenities RoomAmenities { get; set; }
    }
}
