using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.DAL.Concrete
{
    public class EventUserConnectionRepository : Repository<UserEventList>, IEventUserConnectionRepository
    {
        public EventUserConnectionRepository(MapAppDbContext ctx) : base(ctx) { }



    }
}
