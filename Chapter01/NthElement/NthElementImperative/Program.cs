using System;
using System.Collections.Generic;
using System.Linq;

namespace NthElementImperative
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            List<int> listing =
                new List<int>() {
                    0, 1, 2, 3, 4, 5,
                    6, 7, 8, 9, 10, 11,
                    12, 13, 14, 15, 16 };

            var list3rd_imper = NthImperative(listing, 3);
            PrintIntList("Nth Imperative", list3rd_imper);

            var list3rd_funct = NthFunctional(listing, 3);
            PrintIntList("Nth Functional", list3rd_funct);
        }
    }

    public partial class Program
    {
        static List<int> NthImperative(List<int> list, int n)
        {
            var newList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i % n == 0) newList.Add(list[i]);
            }

            return newList;
        }
    }

    public partial class Program
    {
        static List<int> NthFunctional(List<int> list, int n)
        {
            return list.Where((x, i) => i % n == 0).ToList();
        }
    }

    public partial class Program
    {
        static void PrintIntList(
            string titleHeader,
            List<int> list)
        {
            Console.WriteLine(
                String.Format("{0}",
                titleHeader));

            foreach (int i in list)
            {
                Console.Write(String.Format("{0}\t", i));
            }

            Console.WriteLine("\n");
        }
    }
}
