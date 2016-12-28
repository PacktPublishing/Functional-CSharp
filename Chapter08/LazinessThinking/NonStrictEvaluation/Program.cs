using System;

namespace NonStrictEvaluation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            StrictEvaluation();
            NonStrictEvaluation();
        }
    }

    public partial class Program
    {
        private static void StrictEvaluation()
        {
            int x = 4;
            int y = 3;
            int z = 2;

            Console.WriteLine("Strict Evaluation");
            Console.WriteLine(
                String.Format(
                    "Calculate {0} + ({1} * {2})",
                    x,
                    y,
                    z
                    ));

            int result = OuterFormula(x, InnerFormula(y, z));

            Console.WriteLine(
                String.Format(
                    "{0} + ({1} * {2}) = {3}",
                    x,
                    y,
                    z,
                    result
                    ));
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        private static void NonStrictEvaluation()
        {
            int x = 4;
            int y = 3;
            int z = 2;

            Console.WriteLine("Non-Strict Evaluation");
            Console.WriteLine(
                String.Format(
                    "Calculate {0} + ({1} * {2})",
                    x,
                    y,
                    z
                    ));

            int result = OuterFormulaNonStrict(x, InnerFormula);

            Console.WriteLine(
                String.Format(
                    "{0} + ({1} * {2}) = {3}",
                    x,
                    y,
                    z,
                    result
                    ));
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        private static int OuterFormula(int x, int yz)
        {
            Console.WriteLine(
                String.Format(
                    "Calculate {0} + InnerFormula ({1})",
                    x,
                    yz));

            return x * yz;
        }

        private static int InnerFormula(int y, int z)
        {
            Console.WriteLine(
                String.Format(
                    "Calculate {0} * {1}",
                    y,
                    z
                    ));

            return y * z;
        }
    }

    public partial class Program
    {
        private static int OuterFormulaNonStrict(
            int x,
            Func<int, int, int> yzFunc)
        {
            int y = 3;
            int z = 2;

            Console.WriteLine(
                String.Format(
                    "Calculate {0} + InnerFormula ({1})",
                    x,
                    y * z
                    ));

            return x * yzFunc(3, 2);
        }
    }
}
