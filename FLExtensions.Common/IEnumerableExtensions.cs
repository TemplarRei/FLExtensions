namespace FLExtensions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        private static readonly Random rng = new Random(17);

        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = ", ")
        {
            return string.Join(separator, collection);
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if(collection != null)
            {
                foreach (var item in collection)
                {
                    action(item);
                }
            }
            
            return collection;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            if(collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            var result = new HashSet<T>();

            collection.ForEach(i => result.Add(i));

            return result;
        }

        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            var result = new LinkedList<T>();

            collection.ForEach(i => result.AddLast(i));

            return result;
        }

        public static IEnumerable<T> WeakShuffle<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(x => rng.NextBool() ? -1 : 1);
        }
    }
}
