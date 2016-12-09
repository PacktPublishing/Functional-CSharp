using System;
using System.Text;

namespace NonPureFunction2
{
    class Program
    {
        public static void AddSpace(StringBuilder sb, string str)
        {
            sb.Append(' ' + str);
        }

        static void Main(string[] args)
        {
            StringBuilder sb1 = new StringBuilder("First");
            AddSpace(sb1, "Second");
            AddSpace(sb1, "Third");
            Console.WriteLine(sb1);
        }
    }
}
