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
    public class HotelTests
    {
        [Fact]
        public void CanGetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "test name";

            Assert.Equal("test name", hotel.Name);            
        }

        [Fact]
        public void CanSetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "name 1";
            hotel.Name = "name 2";

            Assert.Equal("name 2", hotel.Name);
        }

        [Fact]
        public async void CanCreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Phone = "123-456-7890";
                hotel.Address = "test address string";
                hotel.NumberOfRooms = 10;

                HotelService hotelService = new HotelService(context);

                await hotelService.CreateHotel(hotel);
                var result = await context.Hotel.FirstOrDefaultAsync(h => h.ID == hotel.ID);

                Assert.Equal(result, hotel);
            }

        }

        [Fact]
        public async void CanGetHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetHotel").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Phone = "123-456-7890";
                hotel.Address = "test address string";
                hotel.NumberOfRooms = 10;

                HotelService hotelService = new HotelService(context);

                await hotelService.CreateHotel(hotel);
                var result = await hotelService.GetHotel(hotel.ID);

                Assert.Equal(result, hotel);
            }

        }

        [Fact]
        public async void CanGetHotels()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetHotels").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel1 = new Hotel();
                hotel1.ID = 1;
                hotel1.Name = "test";
                hotel1.Phone = "123-456-7890";
                hotel1.Address = "test address string";
                hotel1.NumberOfRooms = 10;

                Hotel hotel2 = new Hotel();
                hotel2.ID = 2;
                hotel2.Name = "test1";
                hotel2.Phone = "223-456-7890";
                hotel2.Address = "Test address string";
                hotel2.NumberOfRooms = 3;

                HotelService hotelService = new HotelService(context);

                await hotelService.CreateHotel(hotel1);
                await hotelService.CreateHotel(hotel2);
                var hotelsList = await hotelService.GetHotels();
                var hotels = hotelsList.ToString();

                List<Hotel> resultsList = new List<Hotel>();
                resultsList.Add(hotel1);
                resultsList.Add(hotel2);
                var results = resultsList.ToString();

                Assert.Equal(results, hotels);
            }

        }
        [Fact]
        public async void CanEditHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("EditHotels").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Phone = "123-456-7890";
                hotel.Address = "test address string";
                hotel.NumberOfRooms = 10;

                HotelService hotelService = new HotelService(context);

                await hotelService.CreateHotel(hotel);

                hotel.Name = "new name";
                await hotelService.UpdateHotel(hotel);

                var result = await context.Hotel.FirstOrDefaultAsync(h => h.ID == hotel.ID);

                Assert.Equal(result, hotel);
            }

        }
        [Fact]
        public async void CanDeleteHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotels").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Phone = "123-456-7890";
                hotel.Address = "test address string";
                hotel.NumberOfRooms = 10;

                HotelService hotelService = new HotelService(context);

                await hotelService.CreateHotel(hotel);
                await hotelService.DeleteHotel(hotel.ID);

                var result = await context.Hotel.FirstOrDefaultAsync(h => h.ID == hotel.ID);

                Assert.Null(result);
            }

        }
    }
}
