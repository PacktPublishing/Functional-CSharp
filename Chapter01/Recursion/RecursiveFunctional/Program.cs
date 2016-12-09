using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveFunctional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Enter an integer number (Functional approach)");
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            IEnumerable<int> ints = Enumerable.Range(1, inputNumber);
            int factorialNumber = ints.Aggregate((f, s) => f * s);
            Console.WriteLine(
                "{0}! is {1}",
                inputNumber,
                factorialNumber);
        }
    }
}
