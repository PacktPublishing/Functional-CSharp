using System;
using System.Text;

namespace TraditionalMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder("0123", 10);
            sb.Append(new char[] { '4', '5', '6' });
            sb.AppendFormat("{0}{1}{2}", 7, 8, 9);
            sb.Insert(0, "number: ");
            sb.Replace('n', 'N');
            var str = sb.ToString();
            Console.WriteLine(str);
        }
    }
}
