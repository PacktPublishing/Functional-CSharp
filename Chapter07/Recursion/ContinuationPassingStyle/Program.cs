using System;

namespace ContinuationPassingStyle
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GetFactorialOfFiveUsingCPS();
        }
    }

    public partial class Program
    {
        private static void GetFactorialOfFiveUsingCPS()
        {
            Console.Write(
                "5! (using GetFactorialCPS) is ");
            GetFactorialCPS(
                5, 
                x => Console.WriteLine(x));
        }
    }

    public partial class Program
    {
        public static void GetFactorialCPS(
            int intNumber,
            Action<int> actCont)
        {
            if (intNumber == 0)
                actCont(1);
            else
                GetFactorialCPS(
                    intNumber - 1,
                    x => actCont(
                        intNumber * x));
        }
    }
}
