using CleanNsb.Domain;
using CleanNsb.Meters;
using CleanNsb.Meters.Events;
using CleanNsb.Shared.Model;
using NServiceBus;
using System.Threading.Tasks;

namespace CleanNsb.Service
{
    public class InitialReadHandler : IHandleMessages<MeterReadingTaken>
    {
        // TODO - add a context finder to the NSB IMessageHandlerContext
        private readonly MetersAggregateRoot aggregate;

        private readonly MeterReadingTakenFeature feature;

        public InitialReadHandler(MetersAggregateRoot aggregate, MeterReadingTakenFeature feature)
        {
            this.aggregate = aggregate;
            this.feature = feature;
        }

        public async Task Handle(MeterReadingTaken message, IMessageHandlerContext context)
        {
            var meter = aggregate.Load(Mpxn.From(message.Mpxn));
            await feature.UseContext(context.Wrap()).Handle(meter, message.Reading);
        }
    }

    internal static class ContextExtension
    {
        internal static MessageContext Wrap(this IMessageHandlerContext context) => new NServiceBusMessageContext(context);
    }
}