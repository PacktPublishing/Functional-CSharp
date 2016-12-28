using System;

namespace TailRecursion
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            TailCall(5);
        }
    }

    public partial class Program
    {
        public static void TailCall(
            int iTotalRecursion)
        {
            Console.WriteLine(
                "Value: " +
                iTotalRecursion);

            if (iTotalRecursion == 0)
            {
                Console.WriteLine("The tail is executed");
                return;
            }

            TailCall(iTotalRecursion - 1);
        }
    }
}
