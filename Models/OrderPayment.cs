using System;

namespace POSApi.Models
{
    public class OrderPayment
    {
        public ulong Order {get; set;}
        public int Type {get; set;} //enum
        public double Value {get; set;}
    }
}