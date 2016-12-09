<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExpressionSyntax
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            InvokingQueryExpression();
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
        private static void InvokingQueryExpression()
        {
            IEnumerable<string> query =
                from n in names
                where n.Length > 4
                orderby n[0]
                select n.ToUpper();

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExpressionSyntax
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            InvokingQueryExpression();
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
        private static void InvokingQueryExpression()
        {
            IEnumerable<string> query =
                from n in names
                where n.Length > 4
                orderby n[0]
                select n.ToUpper();

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }
}
>>>>>>> origin/master
