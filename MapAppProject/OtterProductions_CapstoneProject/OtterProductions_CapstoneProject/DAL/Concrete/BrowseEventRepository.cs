using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OtterProductions_CapstoneProject.DAL.Concrete
{
    public class BrowseEventRepository : Repository<Event>, IBrowseEventRepository
    {
        private readonly MapAppDbContext _context;
        public BrowseEventRepository(MapAppDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Event> GetAllEventsWithinTwoWeeks(DateOnly today)
        {
            //We are going to grab all events within the two week span
            DateOnly endWindow = today.AddDays(14);
            IEnumerable<Event> eventsWindow = new List<Event>();

            foreach (var AnEvent in _context.Events)
            {
                if (DateOnly.FromDateTime(AnEvent.EventDate) >= today && DateOnly.FromDateTime(AnEvent.EventDate) <= endWindow)
                {
                    eventsWindow = eventsWindow.Append(AnEvent);
                }
            }
            eventsWindow = eventsWindow.ToList();
            return eventsWindow;
        }

        public IEnumerable<Event> GetAllEventsWithinTwoWeeksAndTheLocation(CityState cityStateLocation, DateOnly today)
        {
            //We are going to grab all events within the city and state radius and within the two week span
            DateOnly endWindow = today.AddDays(14);
            IEnumerable<Event> eventsWindow = new List<Event>();

            foreach (var AnEvent in _context.Events)
            {
                if (DateOnly.FromDateTime(AnEvent.EventDate) >= today && DateOnly.FromDateTime(AnEvent.EventDate) <= endWindow)
                {
                    if (AnEvent.EventLocation.Contains(cityStateLocation.state) && AnEvent.EventLocation.Contains(cityStateLocation.city))
                    {
                        eventsWindow = eventsWindow.Append(AnEvent);
                    }
                }
            }
  
            eventsWindow = eventsWindow.ToList();
            return eventsWindow;
        }

        public Event GetEventById(int id)
        {
            return FindById(id);
        }

        public IEnumerable<Event> GetEventByName(string name)
        {
            // Assuming events is the collection of events you want to search through
            // Replace "events" with your actual collection name
            var matchingEvents = _context.Events.Where(e => e.EventName == name).ToList();
            return matchingEvents;
          
/*            IEnumerable<Event> eventsListName = new List<Event>();

            foreach (var AnEvent in _context.Events)
            {
                if (DateOnly.FromDateTime(AnEvent.EventDate) >= today && DateOnly.FromDateTime(AnEvent.EventDate) <= endWindow)
                {
                    eventsWindow = eventsWindow.Append(AnEvent);
                }
            }
            eventsWindow = eventsWindow.ToList();
            return eventsWindow;*/
        }
    }
}