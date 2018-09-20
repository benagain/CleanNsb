using System;
using System.Collections.Generic;
using System.Linq;

namespace EventuallyPoc.Utility
{
    public static class CollectionFindOrCreate
    {
        public static T FindOrCreate<T>(this ICollection<T> context, Func<T, bool> predicate, Func<T> creator)
        {
            var found = context.FirstOrDefault(predicate);

            return found.IsNullOrDefault()
                ? context.Create(creator)
                : found;
        }

        private static bool IsNullOrDefault<T>(this T item) => Equals(item, default(T));

        private static T Create<T>(this ICollection<T> context, Func<T> creator)
        {
            var item = creator();
            context.Add(item);
            return item;
        }
    }
}