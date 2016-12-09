using System;
using System.Collections.Generic;
using System.Linq;

namespace LazyInitialization
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            LazyInitName("Matthew Maxwell");
        }
    }

    public partial class Program
    {
        private static  void LazyInitName(string NameOfPerson)
        {
            Lazy<PersonName> pn =
                new Lazy<PersonName>(
                    () =>
                        new PersonName(NameOfPerson));

            Console.WriteLine(
                "Status: PersonName has been defined.");

            if (pn.IsValueCreated)
            {
                Console.WriteLine(
                    "Status: PersonName has been initialized.");
            }
            else
            {
                Console.WriteLine(
                    "Status: PersonName hasn't been initialized.");
            }

            Console.WriteLine(
                String.Format(
                    "Status: PersonName.Name = {0}",
                    (pn.Value as PersonName).Name));

            if (pn.IsValueCreated)
            {
                Console.WriteLine(
                    "Status: PersonName has been initialized.");
            }
            else
            {
                Console.WriteLine(
                    "Status: PersonName hasn't been initialized.");
            }
        }
    }

    public class PersonName
    {
        public string Name { get; set; }

        public PersonName(string name)
        {
            Name = name;

            Console.WriteLine(
                "Status: PersonName constructor has been called."
                );
        }
    }
}
