using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Utilities
{
    public class SearchService
    {
        private  MapAppDbContext _context;
        public SearchService(MapAppDbContext ctx)
        {
            _context = ctx; 
        }
        public List<Organization> Search(string orgName, string orgLocation)
        {

           
               var organizaitons = new List<Organization>();
            if (string.IsNullOrEmpty(orgName) && string.IsNullOrEmpty(orgLocation))
            {
                organizaitons = _context.Organizations.ToList();
                return organizaitons;
            }
            else if (!string.IsNullOrEmpty(orgName) && string.IsNullOrEmpty(orgLocation))
            {
                organizaitons =  _context.Organizations.Where(x => x.OrganizationName.Contains(orgName)).ToList();
                return organizaitons;
            }
            else  if (string.IsNullOrEmpty(orgName) && !string.IsNullOrEmpty(orgLocation))
            {
                organizaitons = _context.Organizations.Where(x => x.OrganizationLocation.Contains(orgLocation)).ToList();
                return organizaitons;
            }
            else if (!string.IsNullOrEmpty(orgName) && !string.IsNullOrEmpty(orgLocation))
            {
                organizaitons =  _context.Organizations.Where(x => x.OrganizationLocation.Contains(orgLocation)  && x.OrganizationName.Contains(orgName)).ToList();
              return organizaitons;
            }

            else
            {
              return organizaitons;
            }
           
        }
           

            
        
    }
}
