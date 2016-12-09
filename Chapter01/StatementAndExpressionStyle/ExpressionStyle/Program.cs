using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionStyle
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Sign of -15 is {0}",
                GetSign(-15));
        }
    }

    public partial class Program
    {
        public static string GetSign(int val)
        {
            return val > 0 ? "positive" : "negative";
        }
    }
}
