using AsyncInnApp.Data;
using AsyncInnApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class RoomService : IRoom
    {

        private AsyncInnDbContext _context { get; }

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }


        public async Task<Room> GetRoom(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(r => r.ID == id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
