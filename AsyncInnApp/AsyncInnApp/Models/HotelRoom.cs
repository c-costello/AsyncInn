﻿using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }



        public decimal RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }


        // Navigational Properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }


    }
}
