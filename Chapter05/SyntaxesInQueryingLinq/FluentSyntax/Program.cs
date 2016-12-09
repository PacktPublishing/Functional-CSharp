using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentSyntax
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //UsingExtensionMethod();
            UsingStaticMethod();
        }
    }

    public partial class Program
    {
        static List<string> names = new List<string>
        {
            "Howard", "Pat",
            "Jaclyn", "Kathryn",
            "Ben", "Aaron",
            "Stacey", "Levi",
            "Patrick", "Tara",
            "Joe", "Ruby",
            "Bruce", "Cathy",
            "Jimmy", "Kim",
            "Kelsey", "Becky",
            "Scott", "Dick"
        };
    }

    public partial class Program
    {
        private static void UsingExtensionMethod()
        {
            IEnumerable<string> query = 
                names
                    .Where(n => n.Length > 4)
                    .OrderBy(n => n[0])
                    .Select(n => n.ToUpper());

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    public partial class Program
    {
        private static void UsingStaticMethod()
        {
            IEnumerable<string> query =
                Enumerable.Select(
                    Enumerable.OrderBy(
                        Enumerable.Where(
                            names, n => n.Length > 4), 
                        n => n[0]), 
                    n => n.ToUpper());

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }
}
