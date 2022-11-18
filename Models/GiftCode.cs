using System;

namespace CategoryApi.Models
{
    public class GiftCode
    {
        public ulong Id {get; set;}
        public string Code {get; set;}
        public int Status {get; set;}
        public ushort Value {get; set;}
        public dateTime ExpirationDate {get; set;}
        public ulong Order {get; set;}
    }
}