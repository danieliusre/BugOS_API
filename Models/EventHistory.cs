namespace EventHistoryApi.Models
{
    public class EventHistory
    {
        public ulong Id {get; set;}
        public DateTime Date {get; set;}
        public string EventInformation { get; set;}
        public ulong Employee {get; set;}
    }
}