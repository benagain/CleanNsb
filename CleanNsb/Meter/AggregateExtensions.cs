using System;

namespace CleanNsb.Domain
{
    public static class AggregateExtensions
    {
        public static TEntity Load<TEntity, TIndex>(this AggregateRoot<TEntity, TIndex> aggregate, TIndex id) where TEntity : class
        {
            if (aggregate.TryFindById(id, out var found))
                return found;
            else
                throw new Exception($"{typeof(TEntity).Name} `{id}` not found.");
        }
    }
}