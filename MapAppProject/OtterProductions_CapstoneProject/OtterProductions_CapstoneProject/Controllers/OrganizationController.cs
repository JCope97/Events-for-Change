using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using NUnit.Framework;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.ViewModel;

namespace OtterProductions_CapstoneProject.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly MapAppDbContext _context;
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrganizationController(MapAppDbContext context, AuthenticationDbContext authenticationDbContext, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _authenticationDbContext = authenticationDbContext;
            _signInManager = signInManager;
        }

        // GET: Organization
        public async Task<IActionResult> Index()
        {
            return _context.Organizations != null ?
                        View(await _context.Organizations.ToListAsync()) :
                        Problem("Entity set 'MapAppDbContext.Organizations'  is null.");
        }

        // GET: Organization/Details/5

        public async Task<IActionResult> OrganizationDetails(string? id)
        {
            var userDtaeils = _context.Organizations.Where(x => x.Email == id).FirstOrDefault();

            return View(userDtaeils);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Organizations == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }
        [Authorize(Roles = "Organization")]
        [HttpGet]
        public async Task<IActionResult> EditOrganization(string ids)
        {
            //var user = await _userManager.GetUserAsync(User);
            //// get the user manager from the owin context
            //// get user roles
            //var roles = await _userManager.GetRolesAsync(user);


            if (ids == null)
            {
                return View();
            }
            var edit = _context.Organizations.Where(x => x.Email == ids).FirstOrDefault();
            if (edit == null)
            {
                return NotFound();

            }
            //toDo: We need to user the Autompper
            var editOrg = new OrganizationViewModel()
            {
                Address = edit.Address,
                Email = edit.Email,
                OrganizationDescription = edit.OrganizationDescription,
                OrganizationName = edit.OrganizationName,
                OrganizationLocation = edit.OrganizationLocation,
                PhoneNumber = edit.PhoneNumber,
                AspnetIdentityId = edit.AspnetIdentityId,
                Id = edit.Id,
                OrganizationPicture = edit.OrganizationPicture,
                ImageUrl = edit.ImageUrl,
                OldEmail = edit.Email
            };
            return View(editOrg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrganization(OrganizationViewModel organization)
        {
            if (organization.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editOrg = _context.Organizations.Where(x => x.Id == organization.Id).FirstOrDefault();
                    
                    if (editOrg == null)
                        return NotFound();

                    var hasEmailChanged = editOrg.Email != organization.Email;

                    editOrg.Address = organization.Address;
                    editOrg.Email = organization.Email;
                    editOrg.OrganizationDescription = organization.OrganizationDescription;
                    editOrg.OrganizationName = organization.OrganizationName;
                    editOrg.OrganizationLocation = organization.OrganizationLocation;
                    editOrg.PhoneNumber = organization.PhoneNumber;
                    editOrg.AspnetIdentityId = organization.AspnetIdentityId;
                    editOrg.Id = organization.Id;
                    editOrg.OrganizationPicture = organization.OrganizationPicture;
                    editOrg.ImageUrl = organization.ImageUrl;


                    _context.Update(editOrg);
                    await _context.SaveChangesAsync();

                   var user= _authenticationDbContext.Users.FirstOrDefault(x=>x.Email == organization.OldEmail);
                    if(user!=null)
                    {
                        user.PhoneNumber = organization.PhoneNumber;
                        user.Email = organization.Email;
                        user.UserName = organization.Email;
                        user.NormalizedEmail = organization.Email.ToUpper();
                        user.NormalizedUserName = organization.Email.ToUpper();
                        _authenticationDbContext.Users.Update(user);
                       await _authenticationDbContext.SaveChangesAsync();
                    }

                    if (hasEmailChanged)
                    {
                        await _signInManager.SignOutAsync();
                    }

                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(organization);
        }
        // GET: Organization/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AspnetIdentityId,Email,OrganizationName,OrganizationDescription,OrganizationLocation,Address,PhoneNumber,OrganizationLoginId")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        // GET: Organization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organizations == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AspnetIdentityId,Email,OrganizationName,OrganizationDescription,OrganizationLocation,Address,PhoneNumber,OrganizationLoginId")] Organization organization)
        {
            if (id != organization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.Id))
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
            return View(organization);
        }

        // GET: Organization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organizations == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organizations == null)
            {
                return Problem("Entity set 'MapAppDbContext.Organizations'  is null.");
            }
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                _context.Organizations.Remove(organization);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(int id)
        {
            return (_context.Organizations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        // GET: Organization/Events
        public async Task<IActionResult> Events()
        {

            var result = await _context.Events.Where(x => x.OrganizationId == 1).ToListAsync();

            return View(result);
        }
        [HttpGet()]
        public IActionResult CreateEvent()
        {
            return View(new Event());
        }
        [HttpPost()]
        public async Task<IActionResult> CreateEvent(Event model)

        {
            model.EventDate = DateTime.Now;
            model.OrganizationId = 1;
            await _context.Events.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Events");
        }
    }
}
