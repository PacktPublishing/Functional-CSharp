using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPatternCSharp7
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            SwitchCaseInCSharp7();
        }
    }

    public partial class Program
    {
        private static object GetData(
            bool objectType = true)
        {
            if (objectType)
                return "One";
            else
                return 1;
        }
    }

    public partial class Program
    {
        private static void IsOperatorBeforeCSharp7()
        {
            object o = GetData();
            if (o is String)
            {
                var s = (String)o;
                Console.WriteLine(
                    "The object is String. Value = {0}",
                    s);
            }
        }
    }

    public partial class Program
    {
        private static void IsOperatorInCSharp7()
        {
            object o = GetData();
            if (o is String s)
            {
                Console.WriteLine(
                    "The object is String. Value = {0}",
                    s);
            }
        }
    }

    public partial class Program
    {
        private static void SwitchCaseInCSharp7()
        {
            object x = GetData(
                false);
            switch (x)
            {
                case string s:
                    Console.WriteLine(
                        "{0} is a string of length {1}",
                        x,
                        s.Length);
                    break;
                case int i:
                    Console.WriteLine(
                        "{0} is an {1} int",
                        x,
                        (i % 2 == 0 ? "even" : "odd"));
                    break;
                default:
                    Console.WriteLine(
                        "{0} is something else",
                        x);
                    break;
            }
        }
    }
}
