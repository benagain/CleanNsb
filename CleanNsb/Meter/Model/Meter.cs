using CleanNsb.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace CleanNsb.Meters.Model
{
    public class Meter
    {
        public Mpxn Id { get; private set; }

        private List<Reading> readings = new List<Reading>();
        public IReadOnlyList<Reading> Readings => readings;

        public Meter(Mpxn id) => Id = id;

        public void AddReading(decimal amount) => readings.Add(new Reading(amount));

        public decimal LatestReading() => readings.LastOrDefault()?.Value ?? 0;
    }
}