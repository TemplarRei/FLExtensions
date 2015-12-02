namespace FLExtensions.Painkillers
{
    // we might need them some day
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    // we hate yagni

    public static class ObjectPainkillers
    {
        public static T Replicate<T>(this T obj)
            where T : class, ICloneable
        {
            return (T)obj.Clone();
        }
    }
}