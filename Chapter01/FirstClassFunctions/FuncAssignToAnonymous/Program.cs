using System;

namespace FuncAssignToAnonymous
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> da =
                i => i * 2;

            int doubledValue = da(2);
        }
    }
}
