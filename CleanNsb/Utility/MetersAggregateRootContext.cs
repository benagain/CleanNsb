using EventuallyPoc.Maybe;
using EventuallyPoc.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventuallyPoc
{
    namespace Domain
    {
        public class MetersAggregateRootContext : IMetersAggregateRootContext
        {
            private List<Meter> Meters { get; set; } = new List<Meter>();

            public Maybe<Meter> FindById(Mpxn id) => Meters.FirstOrDefault(x => x.Id == id);

            public Meter FindOrCreateBySerialNumber(Mpxn id, Func<Meter> creator) =>
                Meters.FindOrCreate(x => x.Id == id, creator);

            public Task SaveChangesAsync() => Task.CompletedTask;
        }
    }
}