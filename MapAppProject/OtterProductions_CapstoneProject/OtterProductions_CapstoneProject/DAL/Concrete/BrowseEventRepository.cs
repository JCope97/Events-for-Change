using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        IEnumerable<EventViewModel> IBrowseEventRepository.GetAllEventsForUser(string id)
        {
            UserViewModel userViewModel = null;
            List<EventViewModel> usersEvents = new List<EventViewModel>();
            var user = _context.MapAppUsers.Where(u => u.AspnetIdentityId== id).FirstOrDefault();
            var userEventConnection = _context.UserEventLists;
            var events = _context.Events;

            EventViewModel eventViewModel = new EventViewModel();
           

            //foreach (var e in events)
            //{
            //    foreach (var uec in userEventConnection)
            //    {
            //        if (uec.Id == e.Id)
            //        {
            //            eventViewModel.EventDate = e.EventDate;
            //            eventViewModel.EventDescription = e.EventDescription;
            //            eventViewModel.EventName = e.EventName;
            //            eventViewModel.EventLocation = e.EventLocation;

            //            usersEvents.Append(eventViewModel);
            //        }
            //    }
            //}

            //userViewModel.EventList = usersEvents;
            //foreach (var user in _context.MapAppUsers)
            //{
            //    if (user.AspnetIdentityId == id)
            //    {
            //        userId = user.Id;
            //        foreach (var i in _context.UserEventLists)
            //        {
            //            if (i.MapAppUser.AspnetIdentityId == id)
            //            {
            //                usersEvents.Append(i.Event);
            //            }

            //        }
            //    }
            //    else
            //    {
            //        return usersEvents;
            //    }
            //}

            foreach (var e in user.UserEventLists)
            {
                eventViewModel.EventDate = e.Event.EventDate;
                eventViewModel.EventDescription = e.Event.EventDescription;
                eventViewModel.EventName = e.Event.EventName;
                eventViewModel.EventLocation = e.Event.EventLocation;
                usersEvents.Add(eventViewModel);
            }
            


            return usersEvents;
        }
    }
}