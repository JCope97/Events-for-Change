using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.ViewModel;

namespace OtterProductions_CapstoneProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly MapAppDbContext _context;
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

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

        [HttpGet]
        public async Task<IActionResult> EditUser(string ids)
        {
            //var user = await _userManager.GetUserAsync(User);
            //// get the user manager from the owin context
            //// get user roles
            //var roles = await _userManager.GetRolesAsync(user);


            if (ids == null)
            {
                return View();
            }
            var edit = _context.MapAppUsers.Where(x => x.Email == ids).FirstOrDefault();
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
                Username = edit.Username,
                PhoneNumber = edit.PhoneNumber,
                AspnetIdentityId = edit.AspnetIdentityId,
                Id = edit.Id,
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
                    editUser.Username = user.Username;
                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.PhoneNumber = user.PhoneNumber;
                    editUser.AspnetIdentityId = user.AspnetIdentityId;
                    editUser.Id = user.Id;



                    _context.Update(editUser);
                    await _context.SaveChangesAsync();

                    var newUser = _authenticationDbContext.Users.FirstOrDefault(x => x.Email == user.OldEmail);
                    if (newUser != null)
                    {
                        newUser.PhoneNumber = user.PhoneNumber;
                        newUser.Email = user.Email;
                        newUser.UserName = user.Username;
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