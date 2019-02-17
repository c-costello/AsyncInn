using System;
using Xunit;
using AsyncInnApp;
using AsyncInnApp.Models;
using AsyncInnApp.Data;
using AsyncInnApp.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AsyncInnApp.Controllers;

namespace AsyncTests
{
    public class HotelRoomsTest
    {

        [Fact]
        public void CanGetAmenitiesID()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 1;
            roomAmen.RoomID = 1;

            Assert.Equal(1, roomAmen.AmenitiesID);

        }

        [Fact]
        public void CanSetAmenitiesID()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 1;
            roomAmen.RoomID = 1;

            roomAmen.AmenitiesID = 2;
            Assert.Equal(2, roomAmen.AmenitiesID);

        }


        [Fact]
        public void CanGetAmentiesRoomID()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 1;
            roomAmen.RoomID = 1;

            Assert.Equal(1, roomAmen.RoomID);
        }

        [Fact]
        public void CanSetAmenitesRoomID()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 1;
            roomAmen.RoomID = 1;

            roomAmen.RoomID = 2;
            Assert.Equal(2, roomAmen.RoomID);

        }
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

        [Fact]
        public async void CanCreateHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotelRoom").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.HotelID = 1;
                hotelRoom.RoomNumber = 101;
                hotelRoom.RoomID = 1;
                hotelRoom.Rate = 100;
                hotelRoom.PetFriendly = true;


                context.HotelRoom.Add(hotelRoom);
                await context.SaveChangesAsync();
                var result = await context.HotelRoom.FirstOrDefaultAsync(h => h.HotelID == hotelRoom.HotelID && h.RoomNumber == hotelRoom.RoomNumber);

                Assert.Equal(result, hotelRoom);
            }

        }


        [Fact]
        public async void CanUpdateHotelRooms()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.HotelID = 1;
                hotelRoom.RoomNumber = 101;
                hotelRoom.RoomID = 1;
                hotelRoom.Rate = 100;
                hotelRoom.PetFriendly = true;


                context.HotelRoom.Add(hotelRoom);
                await context.SaveChangesAsync();
                hotelRoom.Rate = 50;
                context.HotelRoom.Update(hotelRoom);
                await context.SaveChangesAsync();
                var result = await context.HotelRoom.FirstOrDefaultAsync(h => h.HotelID == hotelRoom.HotelID && h.RoomNumber == hotelRoom.RoomNumber);

                Assert.Equal(result, hotelRoom);
            }

        }

        [Fact]
        public async void CanDeleteHotelRooms()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.HotelID = 1;
                hotelRoom.RoomNumber = 101;
                hotelRoom.RoomID = 1;
                hotelRoom.Rate = 100;
                hotelRoom.PetFriendly = true;


                context.HotelRoom.Add(hotelRoom);
                await context.SaveChangesAsync();
                context.HotelRoom.Remove(hotelRoom);
                await context.SaveChangesAsync();
                var result = await context.HotelRoom.FirstOrDefaultAsync(h => h.HotelID == hotelRoom.HotelID && h.RoomNumber == hotelRoom.RoomNumber);

                Assert.Null(result);
            }
        }
    }
}
