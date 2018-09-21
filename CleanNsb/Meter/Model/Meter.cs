using CleanNsb.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace CleanNsb.Meters.Model
{
    public class Meter
    {
        public Mpxn Id { get; private set; }

        public List<decimal> Readings { get; private set; } = new List<decimal>();

        public Meter(Mpxn id) => Id = id;

        public void AddReading(decimal amount) => Readings.Add(amount);

        public decimal LatestReading() => Readings.LastOrDefault();
    }
}