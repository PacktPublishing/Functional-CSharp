using System;

namespace AccumulatorPassingStyle
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //GetFactorialOfFiveUsingAPS();
            GetFactorialOfFiveUsingAPS2();
        }
    }

    public partial class Program
    {
        private static void GetFactorialOfFiveUsingAPS()
        {
            int i = GetFactorialAPS(5);
            Console.WriteLine(
                "5! (using GetFactorialAPS) is {0}",
                i);
        }
    }

    public partial class Program
    {
        public static int GetFactorialAPS(
            int intNumber,
            int accumulator = 1)
        {
            if (intNumber == 0)
            {
                return accumulator;
            }

            return GetFactorialAPS(
                intNumber - 1,
                intNumber * accumulator);
        }
    }

    public partial class Program
    {
        private static void GetFactorialOfFiveUsingAPS2()
        {
            Console.WriteLine(
                "5! (using GetFactorialAPS2)");
            GetFactorialAPS2(5);
        }
    }

    public partial class Program
    {
        public static void GetFactorialAPS2(
            int intNumber,
            int accumulator = 1)
        {
            if (intNumber == 0)
            {
                Console.WriteLine(
                    "The result is " +
                    accumulator);
                return;
            }

            GetFactorialAPS2(
                intNumber - 1,
                intNumber * accumulator);
        }
    }
}
