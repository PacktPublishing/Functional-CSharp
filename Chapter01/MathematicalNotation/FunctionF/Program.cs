using System;

namespace FunctionF
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            int i = f(5);
            Console.WriteLine(i);
        }
    }

    public partial class Program
    {
        public static int f(int x)
        {
            return (4 * x * x - 14 * x - 8);
        }
    }
}
