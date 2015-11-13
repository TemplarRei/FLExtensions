﻿namespace FLExtensions.Common
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

        public static T PrintGeneric<T>(this T obj, string valueSeparator = ": ", string propSeparator = "; ") where T : class
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
            Console.WriteLine(sb.ToString());
            return obj;
        }

        public static T ThrowIfNull<T>(this T data, string message) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException(message);
            }

            return data;
        }

        public static T ThrowIfNull<T>(this T data) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return data;
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