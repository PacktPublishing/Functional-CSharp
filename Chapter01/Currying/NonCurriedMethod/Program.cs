using System;

namespace NonCurriedMethod
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            int add = NonCurriedAdd(2, 3);
            Console.WriteLine(add);
        }
    }

    public partial class Program
    {
        public static int NonCurriedAdd(int a, int b) => a + b;
    }
}
