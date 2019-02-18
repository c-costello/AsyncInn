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

        /// <summary>
        /// Get HotelRooms Index View
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRoom.Include(h => h.Hotel);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Get Details View
        /// </summary>
        /// <param name="hotelID">int</param>
        /// <param name="roomNumber">int</param>
        /// <returns>View</returns>
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

        /// <summary>
        /// Get Create HotelRoom view
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        /// <summary>
        /// Post Create HotelRoom
        /// </summary>
        /// <param name="hotelRoom">HotelRoom</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {

                HotelRoom hotelRoomCheck = await _context.HotelRoom.FirstOrDefaultAsync(h => h.RoomNumber == hotelRoom.RoomNumber && h.HotelID == hotelRoom.HotelID);
                if (hotelRoomCheck != null)
                {
                    return RedirectToAction(nameof(Create));
                }
                    
                
                _context.Add(hotelRoom);
                Hotel hotel = _context.Hotel.FirstOrDefault(h => hotelRoom.HotelID == h.ID);
                hotel.NumberOfRooms++;
                _context.Hotel.Update(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Get Edit 
        /// </summary>
        /// <param name="hotelID">int</param>
        /// <param name="roomNumber">int</param>
        /// <returns>View</returns>
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
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Post Edit
        /// </summary>
        /// <param name="hotelID">int</param>
        /// <param name="roomNumber">int</param>
        /// <param name="hotelroom">HotelRoom</param>
        /// <returns>View</returns>
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

        /// <summary>
        /// Delete HotelRoom
        /// </summary>
        /// <param name="hotelID">int</param>
        /// <param name="roomNumber">int</param>
        /// <returns>View</returns>
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

        /// <summary>
        /// Post Delete HotelRoom
        /// </summary>
        /// <param name="hotelID">int</param>
        /// <param name="roomNumber">int</param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Check if HotelRoom Exists
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        private bool HotelRoomExists(int id)
        {
            return _context.HotelRoom.Any(e => e.RoomNumber == id);
        }
    }
}
