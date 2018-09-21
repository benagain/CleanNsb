using CleanNsb.Shared.Model;
using CleanNsb.Meters.Model;

namespace CleanNsb
{
    public interface MetersAggregateRoot : AggregateRoot<Meter, Mpxn>
    {
    }
}