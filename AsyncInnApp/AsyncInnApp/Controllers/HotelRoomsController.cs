using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnApp.Data;
using AsyncInnApp.Models;

namespace AsyncInnApp.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRoom.Include(h => h.Hotel);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int hotelID, int roomNumber)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(h => h.RoomNumber == roomNumber && h.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Hotel hotel = _context.Hotel.FirstOrDefault(h => hotelRoom.HotelID == h.ID);
            hotel.NumberOfRooms++;
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Hotel, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int hotelID, int roomNumber)
        {

            var hotelRoom = await _context.HotelRoom
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(h => h.RoomNumber == roomNumber && h.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Hotel, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirm(int hotelID, int roomNumber, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelroom)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(h => h.RoomNumber == roomNumber && h.HotelID == hotelID);
            _context.HotelRoom.Remove(hotelRoom);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.HotelRoom.Add(hotelroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelroom.RoomNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", hotelroom.HotelID);
            return View(hotelroom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int hotelID, int roomNumber)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(h => h.RoomNumber == roomNumber && h.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hotelID, int roomNumber)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(h => h.RoomNumber == roomNumber && h.HotelID == hotelID);
            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRoom.Any(e => e.RoomNumber == id);
        }
    }
}
