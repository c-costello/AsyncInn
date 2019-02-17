﻿// <auto-generated />
using System;
using AsyncInnApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInnApp.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20190204051325_collections2")]
    partial class collections2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInnApp.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Minifridge"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Kitchenette"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Jacuzzi"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Free Wifi"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Balcony"
                        });
                });

            modelBuilder.Entity("AsyncInnApp.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfRooms");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "123 Ocean Street",
                            Name = "Poseidon Inn",
                            NumberOfRooms = 0,
                            Phone = "555-555-5555"
                        },
                        new
                        {
                            ID = 2,
                            Address = "123 Spring Street",
                            Name = "Persophene Inn",
                            NumberOfRooms = 0,
                            Phone = "444-555-6666"
                        },
                        new
                        {
                            ID = 3,
                            Address = "123 Moon Street",
                            Name = "Artemis Inn",
                            NumberOfRooms = 0,
                            Phone = "777-555-8888"
                        },
                        new
                        {
                            ID = 4,
                            Address = "123 Sun Street",
                            Name = "Apollo Inn",
                            NumberOfRooms = 0,
                            Phone = "555-999-5555"
                        },
                        new
                        {
                            ID = 5,
                            Address = "123 Wine Street",
                            Name = "Diones Inn",
                            NumberOfRooms = 0,
                            Phone = "555-999-8888"
                        });
                });

            modelBuilder.Entity("AsyncInnApp.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomNumber");

                    b.Property<int>("HotelID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<decimal>("RoomID");

                    b.Property<int?>("RoomID1");

                    b.HasKey("RoomNumber", "HotelID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID1");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("AsyncInnApp.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 1,
                            Name = "Honeymoon Suite"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "Singles Suite"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "Corner Suite"
                        },
                        new
                        {
                            ID = 4,
                            Layout = 2,
                            Name = "Family Suite"
                        },
                        new
                        {
                            ID = 5,
                            Layout = 0,
                            Name = "King Studio"
                        },
                        new
                        {
                            ID = 6,
                            Layout = 4,
                            Name = "PentHouse"
                        });
                });

            modelBuilder.Entity("AsyncInnApp.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("AmenitiesID");

                    b.HasKey("RoomID", "AmenitiesID");

                    b.HasIndex("AmenitiesID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInnApp.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInnApp.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInnApp.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID1");
                });

            modelBuilder.Entity("AsyncInnApp.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInnApp.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInnApp.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
