using EventuallyPoc.Domain;
using System.Threading.Tasks;

namespace EventuallyPoc
{
    namespace Nsb
    {
        public class InitialReadHandler
        {
            private readonly MetersAggregateRootContext context;
            private readonly MeterReadingTakenFeature feature;

            public InitialReadHandler()
            {
                context = new MetersAggregateRootContext();
                feature = new MeterReadingTakenFeature(context, null);
            }

            public async Task Handle(MeterReadingTaken message)
            {
                await feature.Handle(Mpxn.Create(message.Mpxn), message.Reading);
                await context.SaveChangesAsync();
            }
        }
    }
}