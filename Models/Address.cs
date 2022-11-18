namespace POSApi.Models
{
    public class Address
    {
        public ulong Id {get; set;}
        public string AddressLine1 {get; set;}
        public string AddressLine2 {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public string Country {get; set;}
        public string PostalCode {get; set;}
    }
}