namespace PRADaAPI
{
    public class Invoice
    {
        public ulong Id {get; set;}
        public ulong Order {get; set;}
        public string CompanyCode {get; set;}
        public string TaxPayerCode {get; set;}
        public string ReceiverName {get; set;}
        public ulong Address {get; set;}
    }
}