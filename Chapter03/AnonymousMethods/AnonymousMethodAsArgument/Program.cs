using System;
using System.Collections.Generic;

namespace AnonymousMethodAsArgument
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //PrintResult();
            PrintResultLambda();
        }
    }

    public partial class Program
    {
        private static bool IsMultipleOfSeven(int i)
        {
            return i % 7 == 0;
        }
    }

    public partial class Program
    {
        private static int FindMultipleOfSeven(List<int> numList)
        {
            return numList.Find(IsMultipleOfSeven);
        }
    }

    public partial class Program
    {
        static List<int> numbers = new List<int>()
        {
            54, 24, 91, 70, 72, 44, 61, 93,
            73, 3, 56, 5, 38, 60, 29, 32,
            86, 44, 34, 25, 22, 44, 66, 7,
            9, 59, 70, 47, 55, 95, 6, 42
        };
    }

    public partial class Program
    {
        private static void PrintResult()
        {
            Console.WriteLine(
                "The Multiple of 7 from the number list is {0}",
                FindMultipleOfSeven(numbers));
        }
    }

    public partial class Program
    {
        private static int FindMultipleOfSevenLambda(
            List<int> numList)
        {
            return numList.Find(
                delegate (int i)
                {
                    return i % 7 == 0;
                }
                );
        }
    }

    public partial class Program
    {
        private static void PrintResultLambda()
        {
            Console.WriteLine(
                "({0}) The Multiple of 7 from the number list is {1}",
                "Lambda",
                FindMultipleOfSevenLambda(numbers));
        }
    }
}
