using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.ViewModel;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
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
        public ActionResult EditInfo(string id)
        {
            var userId = _userManager.GetUserId(User);

            var data = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).SingleOrDefault();

            return View(data);

        }

        // Used https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
        // as reference for post method (edited as needed)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditInfo(string id, string email, string phoneNumber)
        {
            var userId = _userManager.GetUserId(User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            //These are getting the user's info from the dbs
            
            var userInfo = _userManager.GetUserAsync(User);
            var data2 = _context.MapAppUsers.Where(x => x.AspnetIdentityId == userId).SingleOrDefault();

            //Used code from https://www.yogihosting.com/aspnet-core-identity-create-read-update-delete-users/ for updating below
            //Edited the provided code from above for my situation
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                    user.UserName = email;
                    user.NormalizedEmail = email.ToUpper();
                    user.NormalizedUserName = email.ToUpper();
                }
                else
                {
                    ModelState.AddModelError("", "Email is empty");
                }
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    user.PhoneNumber = phoneNumber;
                }
                else
                {
                    ModelState.AddModelError("", "Phone number is empty");
                }
            }
            //creating tokens to check when changing identity db info
            var tokenPhone = await _userManager.GenerateChangePhoneNumberTokenAsync(await userInfo, user.PhoneNumber);
           // var tokenEmail = await _userManager.GenerateChangeEmailTokenAsync(await userInfo, user.Email);
            // Checking if any such record exist
            if (data2 != null)
            {
                //Updating application db
                data2.PhoneNumber = phoneNumber;
                data2.Email = email;
                
                //user.UserName = user.Email;
               
                //updating identity db
                var updateNum = await _userManager.ChangePhoneNumberAsync(await userInfo, user.PhoneNumber, tokenPhone);
                //var updateEmail = await _userManager.ChangeEmailAsync(await userInfo, user.Email, tokenEmail);
                var change = _context.SaveChanges();

                
                return RedirectToAction("Index", "/Home");
            }
            else
                return View();
        }
    }
}