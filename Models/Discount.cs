namespace DiscountApi.Models
{
    public class Discount
    {
        public ulong Id {get; set;}
        public double Value {get; set;}
        public int DiscountType {get; set;} //enum?
        public dateTime StartDate {get; set;}
        public uint Duration {get; set;}
    }
}