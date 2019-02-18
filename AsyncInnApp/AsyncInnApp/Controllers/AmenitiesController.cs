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
    public class AmenitiesController : Controller
    {
        private readonly IAmenities _context;

        public AmenitiesController(IAmenities context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Details of Amenity
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {


            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Get's create view
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Create
        /// </summary>
        /// <param name="amenities">Amenities</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {

                await _context.CreateAmenity(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        /// <summary>
        /// Get Edit Amenities
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(int id)
        {

            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        /// <summary>
        /// Post Amenities Edit
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="amenities">Amenities</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmenity(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        /// <summary>
        /// Get Delete Amenties 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Delete(int id)
        {


            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Post delete ameneities
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.GetAmenity(id);
            await _context.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if Amenity Exists
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        private bool AmenitiesExists(int id)
        {
            if (_context.GetAmenity(id) != null)
            {
                return false;
            }
            return true;
        }

        //Get Amenities + search
        /// <summary>
        /// Get Amenties + Search
        /// </summary>
        /// <param name="searchString">string</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                return View(await _context.GetAmenities());
            }
            var amenities = await _context.GetAmenities();

            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(amenities);
        }

    }
}
