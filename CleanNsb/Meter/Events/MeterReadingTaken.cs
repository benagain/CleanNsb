namespace CleanNsb.Meters.Events
{
    public class MeterReadingTaken
    {
        public string Mpxn { get; set; }
        public decimal Reading { get; set; }
    }
}