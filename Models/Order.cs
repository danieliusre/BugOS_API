using System;

namespace CategoryApi.Models
{
    public class Order
    {
        public ulong Id {get; set;}
        public int Status {get; set;} //enum
        public dateTime CreationDate {get; set;}
        public dateTime CompletionDate {get; set;}
        public ulong Discount {get; set;}
        public ulong Employee {get; set;}
        public ulong Customer {get; set;}
    }
}