using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public LayoutType Layout { get; set; }
        
        public enum LayoutType { Studio, OneBedroom, TwoBedroom, Suite, Penthouse}

        //navigational properties
        public HotelRoom HotelRoom { get; set; }
        public RoomAmenities RoomAmenities { get; set; }


    }
}
