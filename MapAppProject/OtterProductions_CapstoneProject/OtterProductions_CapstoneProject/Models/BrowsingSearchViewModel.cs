using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace OtterProductions_CapstoneProject.Models
{
    public class BrowsingSearchViewModel
    {
        //Create data types that take in the form data
        
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}

