using System;
using System.Text;

namespace ChainingMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var str =
                new StringBuilder("0123", 10)
                .Append(new char[] { '4', '5', '6' })
                .AppendFormat("{0}{1}{2}", 7, 8, 9)
                .Insert(0, "number: ")
                .Replace('n', 'N')
                .ToString();
            Console.WriteLine(str);
        }
    }
}
