using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using OtterProductions_CapstoneProject.Areas.Identity.Data;

//Controller for MapAppUsers
namespace OtterProductions_CapstoneProject.Controllers
{
    [Authorize(Roles = RoleConstants.USER)]
    public class MapAppUsersController : Controller
    {
        private readonly MapAppDbContext _context;
        public MapAppUsersController(MapAppDbContext context)
        {
            _context = context;
        }

        // GET: MapAppUsers (class example)
        public async Task<IActionResult> Index()
        {
            return View(await _context.MapAppUsers.ToListAsync());
        }

        // GET: MapAppUsers/Details/5 (class example)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        // GET: MapAppUsers/Create (class example)
        public IActionResult Create()
        {
            return View();
        }

        // POST: MapAppUsers/Create (class example)
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AspnetIdentityId,FirstName,LastName")] MapAppUser mapAppUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapAppUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapAppUser);
        }

        //// GET: MapAppUsers/Edit/5 (class example)
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var mapAppUser = await _context.MapAppUsers.FindAsync(id);
        //    if (mapAppUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(mapAppUser);
        //}

        //// POST: MapAppUsers/Edit/5 (class example)
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AspnetIdentityId,FirstName,LastName")] FujiUser fujiUser)
        //{
        //    if (id != fujiUser.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(fujiUser);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FujiUserExists(fujiUser.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(fujiUser);
        //}

        // GET: MapAppUsers/Delete/5 (class example)


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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

        // POST: MapAppUsers/Delete/5 (class example)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapAppUser = await _context.MapAppUsers.FindAsync(id);
            _context.MapAppUsers.Remove(mapAppUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapAppUserExists(int id)
        {
            return _context.MapAppUsers.Any(e => e.Id == id);
        }
    }
}
