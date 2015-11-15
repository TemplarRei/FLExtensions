namespace FLExtensions.Common
{
    using System;
    using System.IO;
    using System.Text;

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

        public static string WriteToFile(this string content, string relPath, Encoding encoding = null)
        {
            File.WriteAllText(relPath, content, encoding ?? Encoding.UTF8);
            return content;
        }

        public static string AppendInFile(this string content, string relPath, Encoding encoding = null)
        {
            File.AppendAllText(relPath, content, encoding ?? Encoding.UTF8);
            return content;
        }
    }
}
