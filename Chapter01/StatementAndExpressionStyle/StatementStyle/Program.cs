using System;

namespace StatementStyle
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
            string posOrNeg;

            if (val > 0)
                posOrNeg = "positive";
            else
                posOrNeg = "negative";

            return posOrNeg;
        }
    }
}
