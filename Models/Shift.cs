using System;

namespace Models
{
    public class Shift
    {
        public ulong Id {get; set;}
        public ulong Employee {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
    }
}