using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //WhereOperator();
            //SimplyTakeAndSkipOperator();
            //NoTakeSkipOperator();
            //TakeAndSkipOperator();
            //TakeWhileAndSkipWhileOperators();
            DistinctOperator();
        }
    }

    public partial class Program
    {
        static List<int> intList = new List<int>
        {
             0,  1,  2,  3,  4,
             5,  6,  7,  8,  9,
            10, 11, 12, 13, 14,
            15, 16, 17, 18, 19
        };
    }

    public partial class Program
    {
        public static void SimplyTakeAndSkipOperator()
        {
            IEnumerable<int> queryTake =
                intList.Take(10);

            Console.WriteLine("Take operator");
            foreach (int i in queryTake)
            {
                Console.Write(String.Format("{0}\t", i));
            }
            Console.WriteLine();

            IEnumerable<int> querySkip =
                intList.Skip(10);

            Console.WriteLine("Skip operator");
            foreach (int i in querySkip)
            {
                Console.Write(String.Format("{0}\t", i));
            }
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void NoTakeSkipOperator()
        {
            IEnumerable<int> intCollection =
                Enumerable.Range(1, 1000000);

            IEnumerable<int> hugeQuery =
                intCollection
                    .Where(h => h % 2 == 0 && h % 7 == 0);

            foreach (int x in hugeQuery)
            {
                Console.WriteLine(x);
            }
        }
    }

    public partial class Program
    {
        public static void TakeAndSkipOperator()
        {
            IEnumerable<int> intCollection =
                Enumerable.Range(1, 1000000);

            IEnumerable<int> hugeQuery =
                intCollection
                    .Where(h => h % 2 == 0 && h % 7 == 0);

            int pageSize = 10;
            for (int i = 0; i < hugeQuery.Count() / pageSize; i++)
            {
                IEnumerable<int> paginationQuery =
                    hugeQuery
                        .Skip(i * pageSize)
                        .Take(pageSize);

                foreach (int x in paginationQuery)
                {
                    Console.WriteLine(x);
                }

                Console.WriteLine(
                    "Press Enter to continue, " +
                    "other key will stop process!");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
        }
    }

    public partial class Program
    {
        public static void TakeWhileAndSkipWhileOperators()
        {
            int[] intArray = { 10, 4, 27, 53, 2, 96, 48 };

            IEnumerable<int> queryTakeWhile =
                intArray.TakeWhile(n => n < 50);

            Console.WriteLine("TakeWhile operator");
            foreach (int i in queryTakeWhile)
            {
                Console.Write(String.Format("{0}\t", i));
            }
            Console.WriteLine();

            IEnumerable<int> querySkipWhile =
                intArray.SkipWhile(n => n < 50);

            Console.WriteLine("SkipWhile operator");
            foreach (int i in querySkipWhile)
            {
                Console.Write(String.Format("{0}\t", i));
            }
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void DistinctOperator()
        {
            string words = "TheQuickBrownFoxJumpsOverTheLazyDog";
            IEnumerable <char> queryDistinct = words.Distinct();

            string distinctWords = "";
            foreach (char c in queryDistinct)
            {
                distinctWords += c.ToString();
            }
            Console.WriteLine(distinctWords);
        }
    }
}
