using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementOperation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //FirstLastOperator();
            //FirstOrDefaultOperator();
            //SingleOperator();
            //ElementAtOperator();
            DefaultIfEmptyOperator();
        }
    }

    public partial class Program
    {
        public static int[] numbers = {
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
        };
    }

    public partial class Program
    {
        public static void FirstLastOperator()
        {
            Console.WriteLine(
                "First Operator: {0}",
                numbers.First());

            Console.WriteLine(
                "First Operator with predicate: {0}",
                numbers.First(n => n % 4 == 0));

            Console.WriteLine(
                "Last Operator: {0}",
                numbers.Last());

            Console.WriteLine(
                "Last Operator with predicate: {0}",
                numbers.Last(n => n % 4 == 0));
        }
    }

    public partial class Program
    {
        public static void FirstOrDefaultOperator()
        {
            //Console.WriteLine(
            //    "First Operator with predicate: {0}",
            //    numbers.First(n => n % 10 == 0));

            Console.WriteLine(
                "First Operator with predicate: {0}",
                numbers.FirstOrDefault(n => n % 10 == 0));
        }
    }

    public partial class Program
    {
        public static void SingleOperator()
        {
            Console.WriteLine(
                "Single Operator for number can be divided by 7: {0}",
                numbers.Single(n => n % 7 == 0));

            //Console.WriteLine(
            //    "Single Operator for number can be divided by 2: {0}",
            //    numbers.Single(n => n % 2 == 0));

            Console.WriteLine(
                "SingleOrDefault Operator: {0}",
                numbers.SingleOrDefault(n => n % 10 == 0));

            //Console.WriteLine(
            //    "SingleOrDefault Operator: {0}",
            //    numbers.SingleOrDefault(n => n % 3 == 0));
        }
    }

    public partial class Program
    {
        public static void ElementAtOperator()
        {
            Console.WriteLine(
                "ElementAt Operator: {0}",
                numbers.ElementAt(5));

            //Console.WriteLine(
            //    "ElementAt Operator: {0}",
            //    numbers.ElementAt(11));

            Console.WriteLine(
                "ElementAtOrDefault Operator: {0}",
                numbers.ElementAtOrDefault(11));
        }
    }

    public partial class Program
    {
        public static void DefaultIfEmptyOperator()
        {
            List<int> numbers = new List<int>();

            //Console.WriteLine(
            //    "DefaultIfEmpty Operator: {0}",
            //    numbers.DefaultIfEmpty());

            foreach (int number in numbers.DefaultIfEmpty())
            {
                Console.WriteLine(
                    "DefaultIfEmpty Operator: {0}", 
                    number);
            }
        }
    }
}
