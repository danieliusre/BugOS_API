using System;

namespace POSApi.Models
{
    public class Discount
    {
        public enum DiscountTypeEnum 
        {
            Friends,
            Family,
            Employee
        }

        public ulong Id {get; set;}
        public double Value {get; set;}
        public DiscountTypeEnum DiscountType {get; set;}
        public DateTime StartDate {get; set;}
        public uint Duration {get; set;}
    }
}