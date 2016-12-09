using System;

namespace RecursiveImperative
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Enter an integer number (Imperative approach)");
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            int factorialNumber = GetFactorial(inputNumber);
            Console.WriteLine(
                "{0}! is {1}",
                inputNumber,
                factorialNumber);
        }
    }

    public partial class Program
    {
        private static int GetFactorial(int intNumber)
        {
            if (intNumber == 0)
            {
                return 1;
            }

            return intNumber * GetFactorial(intNumber - 1);
        }
    }
}