using System;

namespace FuncObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> f = (x) => x + 2;
            int i = f(1);
            Console.WriteLine(i);

            f = (x) => 2 * x + 1;
            i = f(1);
            Console.WriteLine(i);
        }
    }
}
