using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Controllers
{
    public class MapAppUsersController : Controller
    {
        private readonly MapAppDbContext _context;

        public MapAppUsersController(MapAppDbContext context)
        {
            _context = context;
        }

        // GET: MapAppUsers
        public async Task<IActionResult> Index()
        {
              return _context.MapAppUsers != null ? 
                          View(await _context.MapAppUsers.ToListAsync()) :
                          Problem("Entity set 'MapAppDbContext.MapAppUsers'  is null.");
        }

        // GET: MapAppUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MapAppUsers == null)
            {
                return NotFound();
            }

            var mapAppUser = await _context.MapAppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapAppUser == null)
            {
                return NotFound();
            }

            return View(mapAppUser);
        }

        // GET: MapAppUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MapAppUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] MapAppUser mapAppUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapAppUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapAppUser);
        }

        // GET: MapAppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MapAppUsers == null)
            {
                return NotFound();
            }

            var mapAppUser = await _context.MapAppUsers.FindAsync(id);
            if (mapAppUser == null)
            {
                return NotFound();
            }
            return View(mapAppUser);
        }

        // POST: MapAppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] MapAppUser mapAppUser)
        {
            if (id != mapAppUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapAppUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapAppUserExists(mapAppUser.Id))
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
            return View(mapAppUser);
        }

        // GET: MapAppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MapAppUsers == null)
            {
                return NotFound();
            }

            var mapAppUser = await _context.MapAppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapAppUser == null)
            {
                return NotFound();
            }

            return View(mapAppUser);
        }

        // POST: MapAppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MapAppUsers == null)
            {
                return Problem("Entity set 'MapAppDbContext.MapAppUsers'  is null.");
            }
            var mapAppUser = await _context.MapAppUsers.FindAsync(id);
            if (mapAppUser != null)
            {
                _context.MapAppUsers.Remove(mapAppUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapAppUserExists(int id)
        {
          return (_context.MapAppUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
