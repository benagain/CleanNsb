using CleanNsb.Shared.Model;
using FluentAssertions;
using Xunit;

namespace CleanNsb.Tests
{
    public class TestMpxn
    {
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