namespace CleanNsb.Meters.Events
{
    public class MeterReadingTaken
    {
        public int Mpxn { get; set; }

        public decimal Reading { get; set; }
    }
}