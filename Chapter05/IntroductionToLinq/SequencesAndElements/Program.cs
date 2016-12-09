<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SequencesAndElements
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            ExtractArray();
            //ExtractArrayWithMethodSyntax();
        }
    }

    public partial class Program
    {
        static int[] intArray =
        {
             0,  1,  2,  3,  4,  5,  6,  7,  8,  9,
            10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
            20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
            40, 41, 42, 43, 44, 45, 46, 47, 48, 49
        };
    }

    public partial class Program
    {
        public static void ExtractArray()
        {
            IEnumerable<int> extractedData =
                System.Linq.Enumerable.Where
                    (intArray, i => i.IsPrime());

            Console.WriteLine("Prime Number from 0 - 49 are:");
            foreach (int i in extractedData)
                Console.Write("{0} \t", i);
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void ExtractArrayWithMethodSyntax()
        {
            IEnumerable<int> extractedData =
                intArray.Where(i => i.IsPrime());

            Console.WriteLine("Prime Number from 0 - 49 are:");
            foreach (int i in extractedData)
                Console.Write("{0} \t", i);
            Console.WriteLine();
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsPrime(this int i)
        {
            if ((i % 2) == 0)
            {
                return i == 2;
            }
            int sqrt = (int)Math.Sqrt(i);
            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (i % t == 0)
                {
                    return false;
                }
            }
            return i != 1;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SequencesAndElements
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            ExtractArray();
            //ExtractArrayWithMethodSyntax();
        }
    }

    public partial class Program
    {
        static int[] intArray =
        {
             0,  1,  2,  3,  4,  5,  6,  7,  8,  9,
            10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
            20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
            40, 41, 42, 43, 44, 45, 46, 47, 48, 49
        };
    }

    public partial class Program
    {
        public static void ExtractArray()
        {
            IEnumerable<int> extractedData =
                System.Linq.Enumerable.Where
                    (intArray, i => i.IsPrime());

            Console.WriteLine("Prime Number from 0 - 49 are:");
            foreach (int i in extractedData)
                Console.Write("{0} \t", i);
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void ExtractArrayWithMethodSyntax()
        {
            IEnumerable<int> extractedData =
                intArray.Where(i => i.IsPrime());

            Console.WriteLine("Prime Number from 0 - 49 are:");
            foreach (int i in extractedData)
                Console.Write("{0} \t", i);
            Console.WriteLine();
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsPrime(this int i)
        {
            if ((i % 2) == 0)
            {
                return i == 2;
            }
            int sqrt = (int)Math.Sqrt(i);
            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (i % t == 0)
                {
                    return false;
                }
            }
            return i != 1;
        }
    }
}
>>>>>>> origin/master
