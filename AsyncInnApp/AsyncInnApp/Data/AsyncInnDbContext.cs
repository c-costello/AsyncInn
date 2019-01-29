using AsyncInnApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add our composite key associations
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.RoomID, ce.AmenitiesID });

            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.RoomNumber, ce.HotelID });

            //Seed Data
            //seed hotel data
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Poseidon Inn",
                    Address = "123 Ocean Street",
                    Phone = "555-555-5555",
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Persophene Inn",
                    Address = "123 Spring Street",
                    Phone = "444-555-6666",
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Artemis Inn",
                    Address = "123 Moon Street",
                    Phone = "777-555-8888",
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Apollo Inn",
                    Address = "123 Sun Street",
                    Phone = "555-999-5555",
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Diones Inn",
                    Address = "123 Wine Street",
                    Phone = "555-999-8888",
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Honeymoon Suite",
                    Layout = Models.Room.LayoutType.OneBedroom,
                },
                new Room
                {
                    ID = 2,
                    Name = "Singles Suite",
                    Layout = Models.Room.LayoutType.OneBedroom,
                },
                new Room
                {
                    ID = 3,
                    Name = "Corner Suite",
                    Layout = Models.Room.LayoutType.TwoBedroom,
                },
                new Room
                {
                    ID = 4,
                    Name = "Family Suite",
                    Layout = Models.Room.LayoutType.TwoBedroom,
                },
                new Room
                {
                    ID = 5,
                    Name = "King Studio",
                    Layout = Models.Room.LayoutType.Studio,
                },
                new Room
                {
                    ID = 6,
                    Name = "PentHouse",
                    Layout = Models.Room.LayoutType.Penthouse,
                });

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Minifridge",
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Kitchenette",
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Jacuzzi",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Free Wifi"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Balcony",
                }
                );
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom  { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

}
}
