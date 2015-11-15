namespace FLExtensions.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

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

        public static T ThrowIf<T>(this T obj, Func<T, bool> predicate, Exception e)
        {
            if(predicate(obj))
            {
                throw e;
            }

            return obj;
        }

        public static string ToStringGeneric<T>(this T obj, string valueSeparator = ": ", string propSeparator = "; ") where T : class
        {
            var sb = new StringBuilder();

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead)
                {
                    continue;
                }

                if (prop.PropertyType != typeof(string) && prop.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null)
                {
                    var list = prop.GetValue(obj) as IEnumerable;
                    sb.AppendFormat("{0}{1}[{2}]{3}", prop.Name, valueSeparator, JoinIEnumerable(list),
                        propSeparator);
                }
                else if (false)
                {
                    // check if its a complex class and recursively call PrintGeneric
                }
                else
                {
                    sb.AppendFormat("{0}{1}{2}{3}", prop.Name, valueSeparator, prop.GetValue(obj), propSeparator);
                }
            }

            sb.AppendLine();
            return sb.ToString();
        }

        public static T ThrowIfNull<T>(this T data, string message) where T : class
        {
            if (data == null)
            {
                throw new NullReferenceException(message);
            }

            return data;
        }

        public static T ThrowIfNull<T>(this T data) where T : class
        {
            if (data == null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public static bool IsIn<T>(this T obj, ICollection<T> objects)
        {
            if (null == obj)
            {
                throw new ArgumentNullException("obj");
            }

            return objects.Contains(obj);
        }

        public static bool IsIn<T>(this T obj, params T[] objects)
        {
            return obj.IsIn(objects.ToList());
        }

        private static string JoinIEnumerable(IEnumerable enumerable, string separator = " ")
        {
            var sb = new StringBuilder();

            foreach (var item in enumerable)
            {
                sb.Append(item + separator);
            }

            return sb.ToString().Trim();
        }
    }
}