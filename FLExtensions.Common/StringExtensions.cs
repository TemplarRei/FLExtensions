namespace FLExtensions.Common
{
    using System;

    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string a, string b)
        {
            return a.ToLowerInvariant().Contains(b.ToLowerInvariant());
        }
    }
}
