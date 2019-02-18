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
    public class RoomAmenitiesTests
    {
        [Fact]
        public async void CanCreateRoomAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomAmenitiy").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities roomAmenities = new RoomAmenities();
                roomAmenities.AmenitiesID = 1;
                roomAmenities.RoomID = 1;


                context.RoomAmenities.Add(roomAmenities);
                await context.SaveChangesAsync();
                var result = await context.RoomAmenities.FirstOrDefaultAsync(r => r.AmenitiesID == roomAmenities.AmenitiesID && r.RoomID == roomAmenities.RoomID);

                Assert.Equal(result, roomAmenities);
            }

        }

        [Fact]
        public async void CanDeleteHotelRooms()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoomAmenity").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities roomAmenities = new RoomAmenities();
                roomAmenities.AmenitiesID = 1;
                roomAmenities.RoomID = 1;


                context.RoomAmenities.Add(roomAmenities);
                await context.SaveChangesAsync();
                context.RoomAmenities.Remove(roomAmenities);
                await context.SaveChangesAsync();
                var result = await context.RoomAmenities.FirstOrDefaultAsync(r => r.AmenitiesID == roomAmenities.AmenitiesID && r.RoomID == roomAmenities.RoomID);

                Assert.Null(result);
            }
        }
    }
}
