using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OtterProductions_CapstoneProject.Models
{
    public class BrowseViewModel
    {
        //[Required]
        //public string userLocation { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}
