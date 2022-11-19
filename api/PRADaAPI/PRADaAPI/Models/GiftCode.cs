using System;

namespace PRADaAPI
{
    public class GiftCode
    {
        public ulong Id {get; set;}
        public string Code {get; set;}
        public int Status {get; set;}
        public ushort Value {get; set;}
        public DateTime ExpirationDate {get; set;}
        public ulong Order {get; set;}
    }
}