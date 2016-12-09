using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Memoization
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //asdfg();
            //RunFactorial();
            RunFactorialMemoization();
        }
    }

    public partial class Program
    {
        private static int GetFactorial(int intNumber)
        {
            if (intNumber == 0)
            {
                return 1;
            }

            return intNumber * GetFactorial(intNumber - 1);
        }
    }

    public partial class Program
    {
        private static void RunFactorial()
        {
            Stopwatch sw = new Stopwatch();
            int factorialResult = 0;

            Console.WriteLine(
                "RunFactorial() function is called");
            Console.WriteLine(
                "Get factorial of 9216");

            for (int i = 1; i <= 5; i++)
            {
                sw.Restart();
                factorialResult = GetFactorial(9216);
                sw.Stop();

                Console.WriteLine(
                    "Time elapsed ({0}): {1,8} ns",
                    i,
                    sw.ElapsedTicks * 
                        1000000000 / 
                        Stopwatch.Frequency);
            }
        }
    }

    public partial class Program
    {
        private static Dictionary<int, int>
            memoizeDict = new Dictionary<int, int>();

        private static int GetFactorialMemoization(int intNumber)
        {
            if (intNumber == 0)
            {
                return 1;
            }

            if (memoizeDict.ContainsKey(intNumber))
            {
                return memoizeDict[intNumber];
            }

            int i = intNumber * GetFactorialMemoization(
                intNumber - 1);
            memoizeDict.Add(intNumber, i);
            return i;
        }
    }

    public partial class Program
    {
        private static void RunFactorialMemoization()
        {
            Stopwatch sw = new Stopwatch();
            int factorialResult = 0;

            Console.WriteLine(
                "RunFactorialMemoization() function is called");
            Console.WriteLine(
                "Get factorial of 9216");

            for (int i = 1; i <= 5; i++)
            {
                sw.Restart();
                factorialResult = GetFactorialMemoization(9216);
                sw.Stop();

                Console.WriteLine(
                    "Time elapsed ({0}): {1,8} ns",
                    i,
                    sw.ElapsedTicks * 
                        1000000000 / 
                        Stopwatch.Frequency);
            }
        }
    }

    public partial class Program
    {
        private static void asdfg()
        {
            Func<int, int> fib = null;
            fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;
            fib = fib.Memoize();
        }
    }

    public static class ExtMethod
    {
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();
            return a =>
            {
                R value;
                if (map.TryGetValue(a, out value))
                    return value;
                value = f(a);
                map.Add(a, value);
                return value;
            };
        }
    }
}
