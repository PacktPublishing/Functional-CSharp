using System;

namespace SimpleRecursion
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GetFactorialOfFive();
        }
    }

    public partial class Program
    {
        private static void GetFactorialOfFive()
        {
            int i = GetFactorial(5);
            Console.WriteLine(
                "5! is {0}",
                i);
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
}
