namespace FLExtensions.ConsoleDemos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FLExtensions.Common;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(0, 10).ToList();

            // numbers.ForEach(x => Console.Write(x + " "));

            var dict = new Dictionary<string, bool>();

            dict.Insert(t => true, gosho => false, penka => false, ivan => true);

            Console.WriteLine(dict.StringJoin());

            //string[] stuff = { "-120", "10", "3", "3492394", "8", "-1", "-2345324" };

            //// stuff.ForEach(s => s.QuickParse().Print());

            //numbers.ForEach(x => x.QuickPow(4).Print());
        }
    }
}