using System;
using Xunit;
using AsyncInnApp;
using AsyncInnApp.Models;
using AsyncInnApp.Data;
using AsyncInnApp.Models.Services;
using Microsoft.EntityFrameworkCore;

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

        //[Fact]
        //public async void CanCreateHotel()
        //{
        //    DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").
        //    using (AsyncInnDbContext context = new AsyncInnDbContext(options))
        //    {

        //    }

        //}
    }
}
