using CleanNsb.Meters;
using CleanNsb.Meters.Events;
using CleanNsb.Meters.Model;
using CleanNsb.Shared.Model;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CleanNsb.Tests
{
    public class SaveMeterReading
    {
        [Fact]
        public void When_receving_a_reading_then_it_is_saved_against_the_meter()
        {
            var sut = new MeterReadingTakenFeature();
            var meter = new Meter(Mpxn.From("1234"));

            sut.Handle(meter, 12.1m);

            meter.LatestReading().Should().Be(12.1m);
        }

        [Fact]
        public void When_receving_a_reading_then_MeterReadingSaved_is_published()
        {
            var publisher = Substitute.For<MessageContext>();
            var sut = new MeterReadingTakenFeature();
            sut.UseContext(publisher);
            var meter = new Meter(Mpxn.From(1234));

            sut.Handle(meter, 12.1m);

            publisher.Received().Publish(Arg.Is<MeterReadingSaved>(x => x.Meter == "1234"));
        }
    }
}