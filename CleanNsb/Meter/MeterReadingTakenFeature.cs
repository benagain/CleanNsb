using CleanNsb.Meters.Events;
using CleanNsb.Meters.Model;
using System.Threading.Tasks;

namespace CleanNsb.Meters
{
    public class MeterReadingTakenFeature
    {
        private readonly MessageContext message;

        public MeterReadingTakenFeature(MessageContext message)
        {
            this.message = message;
        }

        public Task Handle(Meter meter, decimal reading)
        {
            meter.AddReading(reading);

            message.Publish(new MeterReadingSaved { Meter = meter.Id });

            return Task.CompletedTask;
        }
    }
}