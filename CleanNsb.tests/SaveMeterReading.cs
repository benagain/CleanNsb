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
            var sut = new MeterReadingTakenFeature(Substitute.For<MessageContext>());
            var meter = new Meter(Mpxn.From("1234"));

            sut.Handle(meter, 12.1m);

            meter.LatestReading().Should().Be(12.1m);
        }

        [Fact]
        public void When_receving_a_reading_then_MeterReadingSaved_is_published()
        {
            var publisher = Substitute.For<MessageContext>();
            var sut = new MeterReadingTakenFeature(publisher);
            var meter = new Meter(Mpxn.From(1234));

            sut.Handle(meter, 12.1m);

            publisher.Received().Publish(Arg.Is<MeterReadingSaved>(x => x.Meter == "1234"));
        }

        [Fact]
        public void MpxnEquality()
        {
            Mpxn.From(1234).Should().Be(Mpxn.From(1234));
            (Mpxn.From(1234) == Mpxn.From(1234)).Should().BeTrue();
            (Mpxn.From(1234) != Mpxn.From(1234)).Should().BeFalse();
            Mpxn.From(1234).Should().Be(Mpxn.From("1234"));
            (Mpxn.From(1234) == Mpxn.From("1234")).Should().BeTrue();
            (Mpxn.From(1234) != Mpxn.From("1234")).Should().BeFalse();
            Mpxn.From(1234).Should().Be(1234);
            (Mpxn.From(1234) == 1234).Should().BeTrue();
            (Mpxn.From(1234) != 1234).Should().BeFalse();
            Mpxn.From(1234).Should().Be("1234");
            (Mpxn.From(1234) == "1234").Should().BeTrue();
            (Mpxn.From(1234) != "1234").Should().BeFalse();

            Mpxn.From(1234).Should().NotBe(Mpxn.From(9999));
            (Mpxn.From(1234) == Mpxn.From(9999)).Should().BeFalse();
            (Mpxn.From(1234) != Mpxn.From(9999)).Should().BeTrue();
            Mpxn.From(1234).Should().NotBe(Mpxn.From("9999"));
            (Mpxn.From(1234) == Mpxn.From("9999")).Should().BeFalse();
            (Mpxn.From(1234) != Mpxn.From("9999")).Should().BeTrue();
            Mpxn.From(1234).Should().NotBe(9999);
            (Mpxn.From(1234) == 9999).Should().BeFalse();
            (Mpxn.From(1234) != 9999).Should().BeTrue();
            Mpxn.From(1234).Should().NotBe("9999");
            (Mpxn.From(1234) == "9999").Should().BeFalse();
            (Mpxn.From(1234) != "9999").Should().BeTrue();
            (Mpxn.From(1234) == (string)null).Should().BeFalse();
            (Mpxn.From(1234) != (string)null).Should().BeTrue();
            (Mpxn.From(1234) == (Mpxn)null).Should().BeFalse();
            (Mpxn.From(1234) != (Mpxn)null).Should().BeTrue();
        }
    }
}