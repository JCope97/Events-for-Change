using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.ViewModel;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OtterProductions_CapstoneProject.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly MapAppDbContext _context;
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(MapAppDbContext context, AuthenticationDbContext authenticationDbContext, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _authenticationDbContext = authenticationDbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
        public ActionResult EditInfo(int Userid)
        {
            var userId = _userManager.GetUserId(User);

            var data = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).SingleOrDefault();
            Console.WriteLine(5 + 5);
            Console.WriteLine("Hello");
            Console.WriteLine(data);

            return View(data);

        }

        //https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
        // To specify that this will be
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditInfo(int Userid, ApplicationUser user)
        {


            // Use of lambda expression to access
            // particular record from a database
            //var data = _context.MapAppUsers.FirstOrDefault(x => x.Id == Userid);
            var data2 = _userManager.Users.FirstOrDefault(x => x.Id == Userid.ToString());
            Console.WriteLine(5 + 5);
            Console.WriteLine("Hello");
            Console.WriteLine(data2);
            var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, user.Email);
            // Checking if any such record exist
            if (data2 != null)
            {
                // _userManager.ChangePhoneNumberAsync(data2, user.PhoneNumber, token);
                 _userManager.ChangePhoneNumberAsync(user, data2.PhoneNumber, token);

                //_userManager.ChangePhoneNumberAsync(user, user.PhoneNumber, data2.PhoneNumber);

                //data.FirstName = user.FirstName;
                //data.LastName = user.LastName;
                //data.Email = user.Email;
                //data.PhoneNumber = user.PhoneNumber;
                //data2.FirstName = user.FirstName;
                //data2.LastName = user.LastName;
                //data2.Email = user.Email;
                //data2.PhoneNumber = user.PhoneNumber;

                //_userManager.UpdateAsync(data2);
                //_context.SaveChanges();
                //_authenticationDbContext.SaveChanges();
                //_userManager.SetPhoneNumberAsync(user, )


                // It will redirect
                return RedirectToAction("/Home/Index");
            }
            else
                return View();

        }

        //public IActionResult EditInfo()
        //{
        //    return View();

        //}


        //[HttpGet]
        //public async Task<IActionResult> EditUser(string id)
        //{
        //    var userId = _userManager.GetUserId(User);


        //    if (userId == null)
        //    {
        //        return View();
        //    }
        //    var edit = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).FirstOrDefault();
        //    if (edit == null)
        //    {
        //        return NotFound();

        //    }
        //    //toDo: We need to user the Autompper
        //    var editUser = new UserViewModel()
        //    {
        //        Email = edit.Email,
        //        FirstName = edit.FirstName,
        //        LastName = edit.LastName,
        //        PhoneNumber = edit.PhoneNumber,
        //        OldEmail = edit.Email
        //    };
        //    return View(editUser);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditUser(UserViewModel user)
        //{
        //    var userId = _userManager.GetUserId(User);
        //    if (userId == null)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var editUser = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).FirstOrDefault();

        //            if (editUser == null)
        //                return NotFound();

        //            var hasEmailChanged = editUser.Email != user.Email;


        //            editUser.Email = user.Email;
        //            editUser.FirstName = user.FirstName;
        //            editUser.LastName = user.LastName;
        //            editUser.PhoneNumber = user.PhoneNumber;

        //            _context.Update(editUser);
        //            await _context.SaveChangesAsync();

        //            var newUser = _authenticationDbContext.Users.FirstOrDefault(x => x.Email == user.OldEmail);
        //            if (newUser != null)
        //            {
        //                newUser.PhoneNumber = user.PhoneNumber;
        //                newUser.Email = user.Email;
        //                newUser.NormalizedEmail = user.Email.ToUpper();
        //                newUser.NormalizedUserName = user.Email.ToUpper();
        //                _authenticationDbContext.Users.Update(newUser);
        //                await _authenticationDbContext.SaveChangesAsync();
        //            }

        //            if (hasEmailChanged)
        //            {
        //                await _signInManager.SignOutAsync();
        //            }

        //            return RedirectToAction("Index", "Home");
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
        //    }
        //    return View(user);
        //}


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

        private bool UserExists(int id)
        {
            return (_context.MapAppUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}