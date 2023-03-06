using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.DAL.Abstract
{
    public interface IBrowseEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllEventsWithinTwoWeeks(DateOnly today);
    }
}



