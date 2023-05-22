using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.DAL.Concrete;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Utilities;

namespace OtterProductions_CapstoneProject.Controllers
{

    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MapAppDbContext _context;
       // private readonly UserManager<ApplicationUser> _userManager;
        private IBrowseEventRepository _eventRepository;
        private readonly IEmailSender _emailSender;
        //private readonly BaseUrlConfiguration _baseUrlConfig;

        public HomeController( MapAppDbContext ctx, /*UserManager<ApplicationUser> userManager,*/ IEmailSender emailSender)
        {
          //  _logger = logger;
            _context = ctx;
           // _userManager = userManager;
            _eventRepository = new BrowseEventRepository(_context);
            _emailSender = emailSender;
            // _baseUrlConfig = baseUrlConfig;
        }
        public IActionResult Index()
        {
            return View();
        }
        private Organization GetOrganizationById(int id)
        {
            return _context.Organizations.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            if (string.IsNullOrWhiteSpace(token))
            {

                ViewBag.Message = "Token cannot be null";
                return View();
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Message = "Email cannot be null";
                return View();
            }
            var (verified, message) = await _emailSender.VerifyEmail(token, email);
            if (verified)
            {
                ViewBag.Message = "Email was successfully verified";
                // return Redirect($"{_baseUrlConfig.BaseVeryUrl}");
                // return Redirect($"{_baseUrlConfig.BaseUrlVerify}");
                return View();
            }
            ViewBag.Message = "Email could not be verified";
            return View();
        }
        public async Task<IActionResult> MessageVerifyEmail()
        {
            ViewBag.Message = "Kindly check your email to verify your  account . if  not you can't access the app.";
            return View();
        }
        [HttpPost]
        public IActionResult Index(Location mapLocation)
        {

            return RedirectToAction("Mappage", "Map", mapLocation);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        //public IActionResult Event()
        //{
        //    IEnumerable<Event> events = _context.Events.ToList();
        //    return View(events);
        //}

        [HttpGet]
        public IActionResult Browsing()
        {
            //Creates a viewmodel and grabs the events, eventTypes, and organizations
            BrowseViewModel browseView = new BrowseViewModel();
            browseView.Events = _eventRepository.GetAllEventsWithinTwoWeeks(DateOnly.FromDateTime(DateTime.Now));
            browseView.EventsTypes = _context.EventTypes.ToList();
            /*            //Can't add Organizations until later
                        browseView.Organizations = _context.Organizations.ToList();*/

            return View(browseView);
        }

        [HttpPost]
        public IActionResult Browsing(CityState locationForVM)
        {
            //Creates a viewmodel and grabs the events and organizations within the city and state radius
            BrowseViewModel browseView = new BrowseViewModel();
            browseView.Events = _eventRepository.GetAllEventsWithinTwoWeeksAndTheLocation(locationForVM, DateOnly.FromDateTime(DateTime.Now));
            browseView.EventsTypes = _context.EventTypes.ToList();
            /*            //Can't add Organizations until later
                        browseView.Organizations = _context.Organizations.ToList();*/

            return View(browseView);
        }

        [HttpGet]
        public IActionResult BrowsingSearch()
        {
            CityState locationForVM = new CityState();
            return View(locationForVM);
        }
        [HttpGet]
        public async Task<IActionResult> Organizations(string? orgName, string? orgLocation)
        {
            try
            {
                var organizaitons = new List<Organization>();
                if (string.IsNullOrEmpty(orgName) && string.IsNullOrEmpty(orgLocation))
                {
                     organizaitons = _context.Organizations.ToList();
                    return View(organizaitons);
                }
                if (!string.IsNullOrEmpty(orgName) && string.IsNullOrEmpty(orgLocation))
                {
                    organizaitons =await _context.Organizations.Where(x=>x.OrganizationName.Contains(orgName)).ToListAsync();
                    return View(organizaitons);
                }
                if (string.IsNullOrEmpty(orgName) && !string.IsNullOrEmpty(orgLocation))
                {
                    organizaitons = await _context.Organizations.Where(x => x.OrganizationLocation.Contains(orgLocation)).ToListAsync();
                    return View(organizaitons);
                }

                if (!string.IsNullOrEmpty(orgName) && !string.IsNullOrEmpty(orgLocation))
                {
                     organizaitons = await _context.Organizations.Where(x => x.OrganizationLocation.Contains(orgLocation) 
                                                       && x.OrganizationName.Contains(orgName)).ToListAsync();
                    return View(organizaitons);
                }
                return View(organizaitons);
            }
            catch (Exception ex)
            {

                throw ex;
            }

         
        }


        //[HttpGet]
        //public IActionResult OrginzaitonEvents(int id)
        //{
        //    var events= _context.Events.Include(x=>x.Organization).Where(x=>x.OrganizationId.Equals(id)).ToList();
        //    return View(events);
        //}
        [HttpGet]
        public IActionResult OrginzaitonEvents(int id)
        {
            var organization = GetOrganizationById(id);
            if (organization == null)
            {
                return NotFound(); // Handle the case when the organization is not found
            }
    
            ViewBag.OrganizationName = organization.OrganizationName;
            var events = _context.Events.Include(x => x.Organization).Where(x => x.OrganizationId.Equals(id)).ToList();

            return View(events);
        }

        [HttpGet]
        public IActionResult EventPage(int id)
        {
            EventViewModel eventView = new EventViewModel();
            eventView.EventsTypes = _context.EventTypes.ToList();
            Event newEvent = new Event();
            newEvent = _eventRepository.GetEventById(id);

            eventView.Id = newEvent.Id;
            eventView.EventDate = newEvent.EventDate;
            eventView.EventDescription = newEvent.EventDescription;
            eventView.EventLocation = newEvent.EventLocation;
            eventView.EventName = newEvent.EventName;
            eventView.EventTypeId = newEvent.EventTypeId;
            //eventView.OrganizationName = newEvent.OrganizationNavigation.OrganizationName;

            return View(eventView);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}