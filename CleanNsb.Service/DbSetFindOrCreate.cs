using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CleanNsb.Service
{
    public static class DbSetFindOrCreate
    {
        public static T FindOrCreate<T>(this DbSet<T> context, Func<T, bool> predicate, Func<T> creator) where T : class
        {
            var found = context.FirstOrDefault(predicate);

            return found.IsNullOrDefault()
                ? context.Create(creator)
                : found;
        }

        private static bool IsNullOrDefault<T>(this T item) => Equals(item, default(T));

        private static T Create<T>(this DbSet<T> context, Func<T> creator) where T : class
        {
            var item = creator();
            context.Add(item);
            return item;
        }
    }
}