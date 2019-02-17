using System;
using Xunit;
using AsyncInnApp;
using AsyncInnApp.Models;
using AsyncInnApp.Data;
using AsyncInnApp.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AsyncTests
{
    public class HotelRoomsTest
    {

        public int HotelID { get; set; }
        public int RoomNumber { get; set; }



        public decimal RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        [Fact]
        public void CanGetHotelID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 1;

            Assert.Equal(1, hotelRoom.HotelID);

        }

        [Fact]
        public void CanSetHotelID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 1;
            hotelRoom.HotelID = 2;

            Assert.Equal(2, hotelRoom.HotelID);

        }
        [Fact]
        public void CanGetRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 1;

            Assert.Equal(1, hotelRoom.RoomNumber);

        }

        [Fact]
        public void CanSetRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 1;
            hotelRoom.RoomNumber = 2;

            Assert.Equal(2, hotelRoom.RoomNumber);

        }
        [Fact]
        public void CanGetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 1;

            Assert.Equal(1, hotelRoom.RoomID);
        }

        [Fact]
        public void CanSetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 1;
            hotelRoom.RoomID = 2;

            Assert.Equal(2, hotelRoom.RoomID);
        }

        [Fact]
        public void CanGetRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 100;

            Assert.Equal(100, hotelRoom.Rate);

        }

        [Fact]
        public void CanSetRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 100;
            hotelRoom.Rate = 50;

            Assert.Equal(50, hotelRoom.Rate);
        }

        [Fact]
        public void CanGetPetFriendly()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;

            Assert.True(hotelRoom.PetFriendly);
        }

        [Fact]
        public void CanSetPetFriendly()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;
            hotelRoom.PetFriendly = false;

            Assert.False(hotelRoom.PetFriendly);
        }
    }
}
