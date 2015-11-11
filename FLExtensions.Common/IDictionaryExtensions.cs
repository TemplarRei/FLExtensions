namespace FLExtensions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IDictionaryExtensions
    {
        public static IDictionary<string, T> Insert<T>(this IDictionary<string, T> dict, params Func<string, T>[] projections)
        {
            projections.ForEach(p => dict.Add(p.Method.GetParameters().First().Name, p(string.Empty)));

            return dict;
        }
    }
}