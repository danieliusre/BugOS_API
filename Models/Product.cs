namespace POSApi.Models
{
    public class Product
    {
        public ulong Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}
        public uint Stock {get; set;}
        public string Barcode {get; set;}
        public ulong Category {get; set;}
        public ulong Discount {get; set;}
    }
}