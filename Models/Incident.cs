namespace IncidentApi.Models
{
    public class Incident
    {
        public ulong Id {get; set;}
        public ulong Order {get; set;}
        public ulong Customer {get; set;}
        public ulong Employee {get; set;}
    }
}