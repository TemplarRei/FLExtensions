namespace FLExtensions.Common
{
    using System;

    public static class ObjectExtensions
    {
        public static T CastTo<T>(this object obj)
        {
            return (T)obj;
        }

        public static T Print<T>(this T obj)
        {
            Console.WriteLine(obj);
            return obj;
        }
    }
}