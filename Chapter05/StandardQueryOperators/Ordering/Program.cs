using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordering
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //OrderByOperator();
            //OrderByOperatorWithComparer();
            //OrderByThenByOperator();
            //OrderByThenByOperatorWithComparer();
            OrderByDescendingOperator();
        }
    }

    public partial class Program
    {
        static List<string> nameList = new List<string>()
        {
            "Blair", "Lane", "Jessie", "Aiden",
            "Reggie", "Tanner", "Maddox", "Kerry"
        };
    }

    public partial class Program
    {
        public static void OrderByOperator()
        {
            //IEnumerable<string> query =
            //    nameList.OrderBy(n => n);

            IEnumerable<string> query =
                from n in nameList
                orderby n
                select n;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    public partial class Program
    {
        public static void OrderByOperatorWithComparer()
        {
            IEnumerable<string> query =
                nameList.OrderBy(
                    n => n, 
                    new LastCharacterComparer());

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class LastCharacterComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(
                x[x.Length - 1].ToString(),
                y[y.Length - 1].ToString());
        }
    }

    public partial class Program
    {
        public static void OrderByThenByOperator()
        {
            //IEnumerable<string> query =
            //    nameList
            //        .OrderBy(n => n.Length)
            //        .ThenBy(n => n);

            IEnumerable<string> query =
                from n in nameList
                orderby n.Length, n
                select n;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    public partial class Program
    {
        public static void OrderByThenByOperatorWithComparer()
        {
            IEnumerable<string> query =
                nameList
                    .OrderBy(n => n.Length)
                    .ThenBy(n => n, new LastCharacterComparer());

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    public partial class Program
    {
        public static void OrderByDescendingOperator()
        {
            IEnumerable<string> query =
                from n in nameList
                orderby n descending
                select n;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }
}