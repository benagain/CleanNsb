using EventuallyPoc.Utility;
using System.Threading.Tasks;

namespace EventuallyPoc.Domain
{
    public class MeterReadingTakenFeature
    {
        private readonly IMetersAggregateRootContext context;
        private readonly MessageContext message;

        public MeterReadingTakenFeature(IMetersAggregateRootContext context, MessageContext message)
        {
            this.context = context;
            this.message = message;
        }

        public Task Handle(Mpxn mpxn, decimal reading)
        {
            var meter = context.FindOrCreateBySerialNumber(mpxn, () => new Meter(mpxn));

            meter.AddReading(reading);

            message.Publish(new MeterReadingSaved());

            return Task.CompletedTask;
        }
    }
}