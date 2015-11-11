namespace FLExtensions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ICollectionExtensions
    {
        public static ICollection<T> AddElement<T>(this ICollection<T> collection, T item)
        {
            if(collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            collection.Add(item);

            return collection;
        }

        public static ICollection<T> AddParams<T>(this ICollection<T> collection, params T[] insertees)
        {
            return collection.AddMany(insertees);
        }

        public static ICollection<T> AddMany<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            if (collection == null || range == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            range.ForEach(i => collection.Add(i));

            return collection;
        }
    }
}
