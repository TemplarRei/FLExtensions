namespace FLExtensions.Painkillers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ArrayPainkillers
    {
        public static T[] Replicate<T>(this T[] array)
            where T : struct
        {
            var newArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static T[] Clone<T>(this T[] array)
            where T : class, ICloneable
        {
            var newArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = (T)array[i].Clone();
            }

            return newArray;
        }
    }
}