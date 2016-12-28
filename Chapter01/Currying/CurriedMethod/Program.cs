using System;

namespace CurriedMethod
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            CurriedStyle1();
            CurriedStyle2();
        }
    }

    public partial class Program
    {
        public static Func<int, int> CurriedAdd(int a) => b => a + b;
    }

    public partial class Program
    {
        public static void CurriedStyle1()
        {
            int add = CurriedAdd(2)(3);
            Console.WriteLine(add);
        }
    }

    public partial class Program
    {
        public static void CurriedStyle2()
        {
            var addition = CurriedAdd(2);

            int x = addition(3);
            Console.WriteLine(x);
        }
    }
}
