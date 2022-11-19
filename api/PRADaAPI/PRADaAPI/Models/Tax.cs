namespace PRADaAPI
{
    public class Tax
    {
        public long Id { get; set; }
        public int Type { get; set; } //enum
        public double Value { get; set; }
    }
}