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
    public class AmenitiesTests
    {
        [Fact]
        public void CanGetNameOfAmenity()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "test name";

            Assert.Equal("test name", amenity.Name);
        }

        [Fact]
        public void CanSetNameOfAmenity()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "name 1";
            amenity.Name = "name 2";

            Assert.Equal("name 2", amenity.Name);
        }

        [Fact]
        public async void CanCreateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "test";


                AmenitiesService amenitiesService = new AmenitiesService(context);

                await amenitiesService.CreateAmenity(amenity);
                var result = await context.Amenities.FirstOrDefaultAsync(r => r.ID == amenity.ID);

                Assert.Equal(result, amenity);
            }

        }

        [Fact]
        public async void CanGetAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmenity").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "test";


                AmenitiesService amenitiesService = new AmenitiesService(context);


                await amenitiesService.CreateAmenity(amenity);
                var result = await amenitiesService.GetAmenity(amenity.ID);

                Assert.Equal(result, amenity);
            }

        }

        [Fact]
        public async void CanGetAmenitys()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmenitys").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "test";

                Amenities amenity2 = new Amenities();
                amenity2.ID = 2;
                amenity2.Name = "test";

                AmenitiesService amenitiesService = new AmenitiesService(context);



                await amenitiesService.CreateAmenity(amenity);
                await amenitiesService.CreateAmenity(amenity2);
                var roomsList = await amenitiesService.GetAmenities();
                var rooms = roomsList.ToString();

                List<Amenities> resultsList = new List<Amenities>();
                resultsList.Add(amenity);
                resultsList.Add(amenity2);
                var results = resultsList.ToString();

                Assert.Equal(results, rooms);
            }

        }
        [Fact]
        public async void CanEditAmenitys()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("EditAmenitys").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "test";

                AmenitiesService amenitiesService = new AmenitiesService(context);

                await amenitiesService.CreateAmenity(amenity);

                amenity.Name = "test2";
                await amenitiesService.UpdateAmenity(amenity);
                var result = await context.Amenities.FirstOrDefaultAsync(r => r.ID == amenity.ID);

                Assert.Equal(result, amenity);
            }

        }
        [Fact]
        public async void CanDeleteAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmenitys").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "test";


                AmenitiesService amenitiesService = new AmenitiesService(context);

                await amenitiesService.CreateAmenity(amenity);
                await amenitiesService.DeleteAmenity(amenity.ID);
                var result = await context.Amenities.FirstOrDefaultAsync(r => r.ID == amenity.ID);

                Assert.Null(result);
            }
        }
    }
}
