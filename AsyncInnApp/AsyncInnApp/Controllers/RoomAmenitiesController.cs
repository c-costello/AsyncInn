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
    public class RoomAmenitiesController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Room Amenities Index 
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            ViewData["RoomID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["AmenitiesID"] = new SelectList(_context.Room, "ID", "Name");
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Get Details Room Amenities
        /// </summary>
        /// <param name="id">int?</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Get Create Room Amenities
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        /// <summary>
        /// Post Create Room Amenities
        /// </summary>
        /// <param name="roomAmenities">RoomAmenities</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                Room room = _context.Room.FirstOrDefault(r => r.ID == roomAmenities.RoomID);
                room.NumberOfAmenities++;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        /// <summary>
        /// Get Edit Room Amentities
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenities == null)
            {
                return NotFound();
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        /// <summary>
        /// Post Edit Room Amentities
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="roomAmenities">RoomAmenities</param>
        /// <returns>View</returns>
        [HttpPost]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (id != roomAmenities.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmenities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmenitiesExists(roomAmenities.RoomID))
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
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        /// <summary>
        /// Get Delete Room Amenity
        /// </summary>
        /// <param name="roomID">int</param>
        /// <param name="amenitiesID">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int roomID, int amenitiesID)
        {

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == roomID && m.AmenitiesID == amenitiesID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Post Delete Room Amenitity
        /// </summary>
        /// <param name="roomID">int</param>
        /// <param name="amenitiesID">int</param>
        /// <returns>View</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roomID, int amenitiesID)
        {
            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == roomID && m.AmenitiesID == amenitiesID);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.RoomID == id);
        }
    }
}
