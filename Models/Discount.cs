namespace DiscountApi.Models
{
    public class Discount
    {
        public enum DiscountType 
        {
            Friends,
            Family,
            Employee
        }

        public ulong Id {get; set;}
        public double Value {get; set;}
        public DiscountType DiscountType {get; set;}
        public DateTime StartDate {get; set;}
        public uint Duration {get; set;}
    }
}