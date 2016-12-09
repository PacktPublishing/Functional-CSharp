using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            AddSubtractDelegate();
        }
    }

    public partial class Program
    {
        private delegate void CalculatorDelegate(int a, int b);
    }

    public partial class Program
    {
        private static void Add(int x, int y)
        {
            Console.WriteLine(
                "{0} + {1} = {2}",
                x,
                y,
                x + y);
        }

        private static void Subtract(int x, int y)
        {
            Console.WriteLine(
                "{0} - {1} = {2}",
                x,
                y,
                x - y);
        }

        private static void Multiply(int x, int y)
        {
            Console.WriteLine(
                "{0} * {1} = {2}",
                x,
                y,
                x * y);
        }

        private static void Division(int x, int y)
        {
            Console.WriteLine(
                "{0} / {1} = {2}",
                x,
                y,
                x / y);
        }
    }

    public partial class Program
    {
        private static void AddSubtractDelegate()
        {
            CalculatorDelegate addDel = Add;
            CalculatorDelegate subDel = Subtract;
            CalculatorDelegate mulDel = Multiply;
            CalculatorDelegate divDel = Division;

            CalculatorDelegate multiDel = addDel + subDel;
            multiDel += mulDel;
            multiDel += divDel;
            Console.WriteLine(
                "Invoking multiDel delegate (four methods):");
            multiDel(8, 2);

            multiDel = multiDel - subDel;
            multiDel -= mulDel;
            Console.WriteLine(
                "Invoking multiDel delegate (after subtraction):");
            multiDel(8, 2);
        }
    }
}
