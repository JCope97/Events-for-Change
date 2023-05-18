using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.DAL.Concrete;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MapAppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private IBrowseEventRepository _eventRepository;

        public HomeController(ILogger<HomeController> logger, MapAppDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = ctx;
            _userManager = userManager;
            _eventRepository = new BrowseEventRepository(_context);
        }
        public IActionResult Index()
        {
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
        public IActionResult EventChoice()
        {
            return View();
        }

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
        public IActionResult BrowsingSearch(){
            CityState locationForVM = new CityState();
            return View(locationForVM);
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

        [HttpGet]
        public IActionResult SearchEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchEvent(string name)
        {
            EventViewModel eventView = new EventViewModel();
            eventView.EventsTypes = _context.EventTypes.ToList();
            Event newEvent = new Event();
            newEvent = _eventRepository.GetEventByName(name);
            //newEvent = _context.Events.Find(name);
            //newEvent = _context.Events.FindEvent(name);
            //newEvent = _context.Events.Where(e => e.EventName == name).Select(e => e.EventName);

            if (newEvent == null)
            {
                return NotFound();
            }

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