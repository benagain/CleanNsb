using CleanNsb.Shared.Model;

namespace CleanNsb.Meters.Events
{
    public class MeterReadingSaved
    {
        public Mpxn Meter { get; set; }

        public decimal Reading { get; set; }
    }
}