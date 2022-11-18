namespace CategoryApi.Models
{
    public class Tax
    {
        public ulong Order {get; set;}
        public int Type {get; set;} //enum
        public double Value {get; set;}

    }
}