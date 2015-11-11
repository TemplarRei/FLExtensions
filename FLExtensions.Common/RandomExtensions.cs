namespace FLExtensions.Common
{
    using System;
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
    }
}