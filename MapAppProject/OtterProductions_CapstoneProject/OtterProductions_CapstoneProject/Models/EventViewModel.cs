namespace OtterProductions_CapstoneProject.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public string EventLocation { get; set; } = null!;
        public int EventTypeId { get; set; }
        public string EventDescription { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public string OrganizationName { get; set; } = null!;

        public IEnumerable<EventType> EventsTypes { get; set; }
    }
}
