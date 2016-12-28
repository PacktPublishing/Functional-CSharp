using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOperation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ConcatUnionOperator();
            IntersectExceptOperator();
        }
    }

    public partial class Program
    {
        static int[] sequence1 = { 1, 2, 3, 4, 5, 6 };
        static int[] sequence2 = { 3, 4, 5, 6, 7, 8 };
    }

    public partial class Program
    {
        public static void ConcatUnionOperator()
        {
            IEnumerable<int> concat =
                sequence1.Concat(sequence2);
            IEnumerable<int> union =
                sequence1.Union(sequence2);

            Console.WriteLine("Concat");
            foreach (int i in concat)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Union");
            foreach (int i in union)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void IntersectExceptOperator()
        {
            IEnumerable<int> intersect =
                sequence1.Intersect(sequence2);

            IEnumerable<int> except1 =
                sequence1.Except(sequence2);

            IEnumerable<int> except2 =
                sequence2.Except(sequence1);

            Console.WriteLine(
                "Intersect of Sequence 1 and Sequence2");
            foreach (int i in intersect)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                "Sequence1 Except Sequence2");
            foreach (int i in except1)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine(
                "Sequence2 Except Sequence1");
            foreach (int i in except2)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
