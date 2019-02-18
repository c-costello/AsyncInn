using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnApp.Data;
using AsyncInnApp.Models;
using AsyncInnApp.Models.Interfaces;

namespace AsyncInnApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoom _context;

        public RoomsController(IRoom context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Details Rooms
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Get Create Rooms
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Create Rooms
        /// </summary>
        /// <param name="room">Room</param>
        /// <returns>int</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        /// <summary>
        /// Get Edit Rooms
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int id)
        {

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }
        
        /// <summary>
        /// Post Edit Rooms
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="room">Room</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        /// <summary>
        /// Get Delete Room
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int id)
        {


            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Post Delete Room
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.GetRoom(id);
            await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check is Room Exists
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        private bool RoomExists(int id)
        {
            if (_context.GetRoom(id) != null)
            {
                return false;
            }
            return true;
        }
        //Get Rooms + Search
        /// <summary>
        /// Get Rooms Index + Search rooms
        /// </summary>
        /// <param name="searchString">string</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                return View(await _context.GetRooms());
            }
            var rooms = await _context.GetRooms();

            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(r => r.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(rooms);
        }
    }
}
