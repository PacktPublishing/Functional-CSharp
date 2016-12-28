using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregateExample
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //AggregateInt();
            AggregateString();
        }
    }

    public partial class Program
    {
        private static void AggregateString()
        {
            List<string> listString =
                new List<string>()
                    {
                        "The",
                        "quick",
                        "brown",
                        "fox",
                        "jumps",
                        "over",
                        "the",
                        "lazy",
                        "dog"
                    };

            string stringAggregate =
                listString.Aggregate(
                    (strAll, str) => strAll + " " + str);

            Console.WriteLine(stringAggregate);
        }
    }

    public partial class Program
    {
        private static void AggregateInt()
        {
            List<int> listInt =
                new List<int>()
                    { 1, 2, 3, 4, 5, 6 };

            int addition =
                listInt.Aggregate(
                    (sum, i) => sum + i);

            Console.WriteLine("The sum of listInt is " + addition);
        }
    }
}
