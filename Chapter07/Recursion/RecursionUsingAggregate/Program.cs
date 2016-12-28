using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionUsingAggregate
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GetFactorialAggregate(5);
        }
    }

    public partial class Program
    {
        private static void GetFactorialAggregate(int intNumber)
        {
            IEnumerable<int> ints =
                Enumerable.Range(1, intNumber);
            int factorialNumber =
                ints.Aggregate((f, s) => f * s);
            Console.WriteLine(
                "{0}! (using Aggregate) is {1}",
                intNumber,
                factorialNumber);
        }
    }
}