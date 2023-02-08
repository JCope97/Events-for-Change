using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EventController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> eventList = _db.Events;
            return View(eventList);
        }
  
    }
}


