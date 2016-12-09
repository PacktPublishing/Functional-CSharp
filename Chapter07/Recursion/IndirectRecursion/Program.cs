using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndirectRecursion
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            CheckNumberFive();
        }
    }

    public partial class Program
    {
        private static void CheckNumberFive()
        {
            Console.WriteLine(
                "Is 5 even number? {0}", 
                IsEven(5));
        }
    }

    public partial class Program
    {
        private static bool IsOdd(int targetNumber)
        {
            if (targetNumber == 0)
            {
                return false;
            }
            else
            {
                return IsEven(targetNumber - 1);
            }
        }

        private static bool IsEven(int targetNumber)
        {
            if (targetNumber == 0)
            {
                return true;
            }
            else
            {
                return IsOdd(targetNumber - 1);
            }
        }
    }
}
