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

            var listRange = new List<int>();

            listRange.Range(1, 6, 3);

            Console.WriteLine(listRange.StringJoin());

            var person = new Person("Pesho", "HSRL Rakovski, Bourgas");
            person.Homeworks.Add("1324123413");
            person.Homeworks.Add("32");
            person.Homeworks.Add("5");

            person.PrintGeneric();
        }
    }

    public class Person
    {
        public Person(string name, string school)
        {
            this.Name = name;
            this.School = school;
            this.Homeworks = new List<string>();
        }

        public string Name { get; set; }

        public string School { get; set; }

        public List<string> Homeworks { get; set; }
    }
}