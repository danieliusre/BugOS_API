using System;

namespace CategoryApi.Models
{
    public class OrderItem
    {
        public ulong Product {get; set;}
        public ulong Order {get; set;}
        public double Quantity {get; set;}
        public string Comment {get; set;}
    }
}