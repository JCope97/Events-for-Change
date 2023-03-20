#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Areas.Identity.Pages.Account
{
    public class OrganizationModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IUserStore<ApplicationUser> _userStore;
        //private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AuthenticationDbContext _authDbContext;
        private readonly MapAppDbContext _mapAppDbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrganizationModel(
            UserManager<ApplicationUser> userManager,
            //IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AuthenticationDbContext authDbContext,
            MapAppDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment)

        {
            _userManager = userManager;
            //_userStore = userStore;
            //_emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _authDbContext = authDbContext;
            _mapAppDbContext = context;
            _hostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor; 
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid, Needs to have an email prefix and an email domain, such as example@mail.com")]
            public string Email { get; set; }
         
            // user added fields


            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Organization Name")]
            [RegularExpression("^[\\w'\\-,.][^0-9_!¡?÷?¿/\\\\+=@#$%ˆ&*(){}|~<>;:[\\]]{1,}$", ErrorMessage = "Not a valid input, We do support most languages characters, " +
                "also special characters such as hyphens, spaces, apostrophes and periods.")]
            public string OrganizationName { get; set; }
           
            [Display(Name = "Organization Description")]
            public string OrganizationDescription { get; set; }
            
            [Display(Name = "Organization Location")]
            public string OrganizationLocation { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }
         


            [Required(ErrorMessage = "You must provide a phone number")]
            [Display(Name = "Phone Number")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid phone number, Needs to be digits only")]
            public string PhoneNumber { get; set; }
             public IFormFile ProfileImage { get; set; }
            public string ImageUrl { get; set; }

            [PersonalData]
            [Column(TypeName = "bit")]
            public bool IsOrganization { get; set; }

            //[PersonalData]
            //[Column(TypeName = "varbinary")]
            //public byte[] OrganizationPicture { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile fileUpload,string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            try
            {

                dynamic urlPic = null;
            if (ModelState.IsValid)
            {                
                if (fileUpload != null)
                {           
                    string profilefolder = "images/ProfilePics/";
                    profilefolder +=Guid.NewGuid() + "_" + fileUpload.FileName;
                    
                    Input.ImageUrl = profilefolder;
                    string ProfileServerFolder = Path.Combine(_hostEnvironment.WebRootPath, profilefolder);
                    await fileUpload.CopyToAsync(new FileStream(ProfileServerFolder, FileMode.Create));
                    urlPic = string.Concat(_httpContextAccessor.HttpContext.Request.Scheme, "//", _httpContextAccessor.HttpContext.Request.Host,"/"+ profilefolder);//https//localhost:7196/images/ProfilePics/204aab4e-9310-4850-81c2-9ab1395e737f_Untitled.jpg

                    }
                 

                var user = new ApplicationUser
                {
                    PhoneNumber = Input.PhoneNumber,
                    Email = Input.Email,
                    UserName = Input.Email,
                    IsOrganization = Input.IsOrganization,
                    FirstName = Input.OrganizationName,
                    LastName= Input.OrganizationName,

                };
                  

                    var identityOrganization = new IdentityOrganization
                {
                    User = user,
                    UserId = user.Id
                };

                    //await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                    //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                    var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

               
                    // create our own user
                    Organization ma = new Organization
                    {
                        AspnetIdentityId = user.Id,
                        Email = Input.Email,
                        OrganizationName = Input.OrganizationName,
                        OrganizationDescription = Input.OrganizationDescription,
                        OrganizationLocation = Input.OrganizationLocation,
                        Address = Input.Address,
                        PhoneNumber = Input.PhoneNumber,
                        OrganizationPicture = Input.ImageUrl,
                        ImageUrl = urlPic,


                    };
                      await _mapAppDbContext.Organizations.AddAsync(ma);
                      await _mapAppDbContext.SaveChangesAsync();
                       

                        // assign organization to identity role 'ORGANIZATION'
                     await _userManager.AddToRoleAsync(user, RoleConstants.ORGANIZATION);

                    //var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("ConfirmationPage", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            }
            catch (Exception ex)
            {

                throw;
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }

        //private ApplicationUser CreateUser()
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<ApplicationUser>();
        //    }
        //    catch
        //    {
        //        throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
        //            $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
        //            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        //    }
        //}

        //private IUserEmailStore<ApplicationUser> GetEmailStore()
        //{
        //    if (!_userManager.SupportsUserEmail)
        //    {
        //        throw new NotSupportedException("The default UI requires a user store with email support.");
        //    }
        //    return (IUserEmailStore<ApplicationUser>)_userStore;
        //}
    }
}