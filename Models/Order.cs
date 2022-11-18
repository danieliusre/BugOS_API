using System;

namespace POSApi.Models
{
    public class Order
    {
        public ulong Id {get; set;}
        public int Status {get; set;} //enum
        public DateTime CreationDate {get; set;}
        public DateTime CompletionDate {get; set;}
        public ulong Discount {get; set;}
        public ulong Employee {get; set;}
        public ulong Customer {get; set;}
    }
}