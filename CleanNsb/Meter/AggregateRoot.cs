namespace CleanNsb
{
    public interface AggregateRoot<TEntity, TIndex> where TEntity : class
    {
        bool TryFindById(TIndex id, out TEntity entity);

        void Add(TEntity entity);
    }
}