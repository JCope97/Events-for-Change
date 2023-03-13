using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OtterProductions_CapstoneProject.Models
{
    public class BrowseViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }

        public IEnumerable<EventType> EventsTypes { get; set; }
    }
}
