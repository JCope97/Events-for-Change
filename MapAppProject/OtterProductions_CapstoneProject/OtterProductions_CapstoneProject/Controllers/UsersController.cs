using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace OtterProductions_CapstoneProject.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly MapAppDbContext _context;
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(MapAppDbContext context, AuthenticationDbContext authenticationDbContext, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _authenticationDbContext = authenticationDbContext;
            _signInManager = signInManager;
        }

        public IActionResult EditInfo()
        {
            return View();

        }


        //// GET: Organization/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.MapAppUsers == null)
        //    {
        //        return NotFound();
        //    }

        //    var organization = await _context.MapAppUsers.FindAsync(id);
        //    if (organization == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(organization);
        //}

        //// POST: Organization/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AspnetIdentityId,Email,FirstName,LastName,PhoneNumber")] MapAppUser user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.Id))
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
        //    return View(user);
        //}


        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string id = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(userId);

            //var user = await _context.MapAppUsers.FindAsync(id);
            Debug.WriteLine(user.Id);
            //// get the user manager from the owin context
            //// get user roles
            //var roles = await _userManager.GetRolesAsync(user);


            if (user.Id == null)
            {
                return View();
            }
            var edit = _context.MapAppUsers.Where(x => x.Id == id).FirstOrDefault();
            if (edit == null)
            {
                return NotFound();

            }
            //toDo: We need to user the Autompper
            var editUser = new UserViewModel()
            {
                Email = edit.Email,
                FirstName = edit.FirstName,
                LastName = edit.LastName,
                PhoneNumber = edit.PhoneNumber,
                OldEmail = edit.Email
            };
            return View(editUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModel user)
        {
            if (user.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editUser = _context.MapAppUsers.Where(x => x.Id == user.Id).FirstOrDefault();

                    if (editUser == null)
                        return NotFound();

                    var hasEmailChanged = editUser.Email != user.Email;


                    editUser.Email = user.Email;
                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.PhoneNumber = user.PhoneNumber;

                    _context.Update(editUser);
                    await _context.SaveChangesAsync();

                    var newUser = _authenticationDbContext.Users.FirstOrDefault(x => x.Email == user.OldEmail);
                    if (newUser != null)
                    {
                        newUser.PhoneNumber = user.PhoneNumber;
                        newUser.Email = user.Email;
                        newUser.NormalizedEmail = user.Email.ToUpper();
                        newUser.NormalizedUserName = user.Email.ToUpper();
                        _authenticationDbContext.Users.Update(newUser);
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
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return (_context.MapAppUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}