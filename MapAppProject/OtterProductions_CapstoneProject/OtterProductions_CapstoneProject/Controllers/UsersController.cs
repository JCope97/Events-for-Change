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

        // Used https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
        // as reference for post method 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditInfo(ApplicationUser user)
        {
            var userId = _userManager.GetUserId(User);
            var userInfo = _userManager.GetUserAsync(User);
            var data2 = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).SingleOrDefault();

            var tokenPhone = await _userManager.GenerateChangePhoneNumberTokenAsync(await userInfo, user.PhoneNumber);
            var tokenEmail = await _userManager.GenerateChangeEmailTokenAsync(await userInfo, user.Email);

            // Checking if any such record exist
            if (data2 != null)
            {
                data2.PhoneNumber = user.PhoneNumber;
                data2.Email = user.Email;
               
                var updateNum = _userManager.ChangePhoneNumberAsync(await userInfo, user.PhoneNumber, tokenPhone);
                var updateEmail = _userManager.ChangeEmailAsync(await userInfo, user.Email,tokenEmail);

                var change = _context.SaveChanges();
 
                return RedirectToAction("Index", "/Home");
            }
            else
                return View();
        }
    }
}