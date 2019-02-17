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
    public class RoomTests
    {
        [Fact]
        public void CanGetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "test name";

            Assert.Equal("test name", room.Name);
        }

        [Fact]
        public void CanSetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "name 1";
            room.Name = "name 2";

            Assert.Equal("name 2", room.Name);
        }

        [Fact]
        public async void CanCreateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "test";
                room.Layout = Room.LayoutType.OneBedroom;


                RoomService roomService = new RoomService(context);

                await roomService.CreateRoom(room);
                var result = await context.Room.FirstOrDefaultAsync(r => r.ID == room.ID);

                Assert.Equal(result, room);
            }

        }

        [Fact]
        public async void CanGetRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetRoom").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "test";
                room.Layout = Room.LayoutType.OneBedroom;


                RoomService roomService = new RoomService(context);


                await roomService.CreateRoom(room);
                var result = await roomService.GetRoom(room.ID);

                Assert.Equal(result, room);
            }

        }

        [Fact]
        public async void CanGetRooms()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetRooms").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "test";
                room.Layout = Room.LayoutType.OneBedroom;

                Room room2 = new Room();
                room2.ID = 2;
                room2.Name = "test";
                room2.Layout = Room.LayoutType.OneBedroom;

                RoomService roomService = new RoomService(context);



                await roomService.CreateRoom(room);
                await roomService.CreateRoom(room2);
                var roomsList = await roomService.GetRooms();
                var rooms = roomsList.ToString();

                List<Room> resultsList = new List<Room>();
                resultsList.Add(room);
                resultsList.Add(room2);
                var results = resultsList.ToString();

                Assert.Equal(results, rooms);
            }

        }
        [Fact]
        public async void CanEditRooms()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("EditRooms").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "test";
                room.Layout = Room.LayoutType.OneBedroom;


                RoomService roomService = new RoomService(context);

                await roomService.CreateRoom(room);

                room.Name = "test2";
                await roomService.UpdateRoom(room);
                var result = await context.Room.FirstOrDefaultAsync(r => r.ID == room.ID);

                Assert.Equal(result, room);
            }

        }
        [Fact]
        public async void CanDeleteRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRooms").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "test";
                room.Layout = Room.LayoutType.OneBedroom;


                RoomService roomService = new RoomService(context);

                await roomService.CreateRoom(room);
                await roomService.DeleteRoom(room.ID);
                var result = await context.Room.FirstOrDefaultAsync(r => r.ID == room.ID);

                Assert.Null(result);
            }
        }
    }
}
