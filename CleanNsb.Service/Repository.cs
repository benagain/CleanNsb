using CleanNsb.Meters.Model;
using CleanNsb.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanNsb.Service
{
    public class Repository : DbContext, MetersAggregateRoot
    {
        public DbSet<Meter> Meters { get; set; }

        public bool TryFindById(Mpxn id, out Meter entity)
        {
            entity = Meters.FirstOrDefault(x => x.Id == id);
            return entity != null;
        }

        public void Add(Meter entity) => Meters.Add(entity);
    }
}