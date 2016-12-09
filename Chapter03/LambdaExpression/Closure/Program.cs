using System;

namespace Closure
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> incrementFunc = GetFunction();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                    "Invoking {0}: incrementFunc(1) = {1}",
                    i,
                    incrementFunc(1));
            }
        }
    }

    public partial class Program
    {
        private static Func<int, int> GetFunction()
        {
            int localVar = 1;

            Func<int, int> returnFunc =
                scopeVar =>
                {
                    localVar *= 2;
                    return scopeVar + localVar;
                };

            return returnFunc;
        }
    }
}
