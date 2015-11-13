namespace FLExtensions.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class RandomExtensions
    {
        private const string AllowedSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string NextString(this Random random, int minLength = 0, int maxLength = int.MaxValue / 2, string allowedSymbols = AllowedSymbols)
        {
            var result = new StringBuilder();
            var length = random.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result.Append(allowedSymbols[random.Next(0, allowedSymbols.Length)]);
            }

            return result.ToString();
        }

        public static bool NextBool(this Random random, int truePercantage = 50)
        {
            return random.Next(0, 100) < truePercantage;
        }

        public static decimal NextDecimal(this Random random)
        {
            return (decimal)random.NextDouble();
        }

        public static DateTime NextDateTime(this Random random, DateTime from, DateTime to)
        {
            if (from > to)
            {
                throw new ArgumentException("The 'first' argument must be earlier in time than the 'to' argument!");    
            }

            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        public static T NextOf<T>(this Random random, List<T> objects)
        {
            return objects[random.Next(objects.Count)];
        }

        public static T NextOf<T>(this Random random, params T[] objects)
        {
            return random.NextOf(objects.ToList());
        }
    }
}