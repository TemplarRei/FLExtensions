namespace FLExtensions.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ICollectionExtensions
    {
        public static ICollection<T> AddElement<T>(this ICollection<T> collection, T item)
        {
            if (collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            collection.Add(item);

            return collection;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
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

        public static ICollection<int> Range(this ICollection<int> collection, int start = 0, int elements = 5,
            int incrementor = 1)
        {
            if (collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            if (elements < 0)
            {
                throw new ArgumentException("The number of elements cannot be a negative value!");
            }

            var current = start;

            for (int i = 0; i <= elements; i++)
            {
                collection.Add(current);

                current += incrementor;
            }

            return collection;
        }

        public static ICollection<double> Range(this ICollection<double> collection, double start = 0, int elements = 5,
    double incrementor = 1)
        {
            if (collection == null)
            {
                throw new NullReferenceException("The provided collection was null");
            }

            if (elements < 0)
            {
                throw new ArgumentException("The number of elements cannot be a negative value!");
            }

            var current = start;

            for (int i = 0; i < elements; i++)
            {
                collection.Add(current);

                current += incrementor;
            }

            return collection;
        }
    }
}
