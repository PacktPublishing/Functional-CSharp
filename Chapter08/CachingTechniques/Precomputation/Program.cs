using System;

namespace Precomputation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //WithoutPrecomputation();
            //WithPrecomputation();
            WithPrecomputationFunctional();
        }
    }

    public partial class Program
    {
        private static void WithoutPrecomputation()
        {
            Console.WriteLine("WithoutPrecomputation()");
            Console.Write(
                "Choose number from 0 to 99 twice ");
            Console.WriteLine(
                "to find the power of two result: ");

            Console.Write("First Number: ");
            int iInput1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Second Number: ");
            int iInput2 = Convert.ToInt32(Console.ReadLine());

            int iOutput1 = (int)Math.Pow(iInput1, 2);
            int iOutput2 = (int)Math.Pow(iInput2, 2);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput1,
                iOutput1);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput2,
                iOutput2);
        }
    }

    public partial class Program
    {
        private static int FindThePowerOfTwo(
            int[] precomputeData,
            int baseNumber)
        {
            return precomputeData[baseNumber];
        }
    }

    public partial class Program
    {
        private static void WithPrecomputation()
        {
            int[] powerOfTwos = new int[100];
            for (int i = 0; i < 100; i++)
            {
                powerOfTwos[i] = (int)Math.Pow(i, 2);
            }

            Console.WriteLine("WithPrecomputation()");
            Console.Write(
                "Choose number from 0 to 99 twice ");
            Console.WriteLine(
                "to find the power of two result: ");

            Console.Write("First Number: ");
            int iInput1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Second Number: ");
            int iInput2 = Convert.ToInt32(Console.ReadLine());

            int iOutput1 = FindThePowerOfTwo(powerOfTwos, iInput1);
            int iOutput2 = FindThePowerOfTwo(powerOfTwos, iInput2);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput1,
                iOutput1);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput2,
                iOutput2);
        }
    }

    public partial class Program
    {
        public static Func<int, int>
            CurriedPowerOfTwo(int[] intArray)
                => i => intArray[i];
    }

    public partial class Program
    {
        private static void WithPrecomputationFunctional()
        {
            int[] powerOfTwos = new int[100];
            for (int i = 0; i < 100; i++)
            {
                powerOfTwos[i] = (int)Math.Pow(i, 2);
            }

            Console.WriteLine("WithPrecomputationFunctional()");
            Console.Write(
                "Choose number from 0 to 99 twice ");
            Console.WriteLine(
                "to find the power of two result: ");

            Console.Write("First Number: ");
            int iInput1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Second Number: ");
            int iInput2 = Convert.ToInt32(Console.ReadLine());

            var curried = CurriedPowerOfTwo(powerOfTwos);
            int iOutput1 = curried(iInput1);
            int iOutput2 = curried(iInput2);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput1,
                iOutput1);

            Console.WriteLine(
                "2 the power of {0} is {1}",
                iInput2,
                iOutput2);
        }
    }
}