namespace RaceDay.API.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int OrganiserID { get; set; }
    }
}