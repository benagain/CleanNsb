using EventuallyPoc.Maybe;
using System;

namespace EventuallyPoc.Domain
{
    public interface IMetersAggregateRootContext
    {
        Maybe<Meter> FindById(Mpxn id);

        Meter FindOrCreateBySerialNumber(Mpxn id, Func<Meter> creator);
    }
}