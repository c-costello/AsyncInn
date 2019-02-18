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
    public class HotelsController : Controller
    {
        private readonly IHotel _context;

        public HotelsController(IHotel context)
        {
            _context = context;
        }


        /// <summary>
        /// Get Hotel Details
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {


            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// Get Create Hotel
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Create Hotel
        /// </summary>
        /// <param name="hotel">Hotel</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {

                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        /// <summary>
        /// Get Edit Hotel
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        /// <summary>
        /// Post Edit Hotel
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="hotel">Hotel</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { 

                    await _context.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        /// <summary>
        /// Get Delete Hotel
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int id)
        {

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// Post Delete Hotel
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.GetHotel(id);
            await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// Check if Hotel Exists
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        private bool HotelExists(int id)
        {
            if (_context.GetHotel(id) != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get Index Hotels and Search Hotels
        /// </summary>
        /// <param name="searchString">string</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                return View(await _context.GetHotels());
            }
            var hotels = await _context.GetHotels();

            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(hotels);
        }
    }
}
