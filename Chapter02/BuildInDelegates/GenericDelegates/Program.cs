<<<<<<< HEAD
﻿using System;

namespace GenericDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GenericDelegateInvoke();
        }
    }

    public partial class Program
    {
        private delegate T FormulaDelegate<T>(T a, T b);
    }

    public partial class Program
    {
        private static int AddInt(int x, int y)
        {
            return x + y;
        }

        private static double AddDouble(double x, double y)
        {
            return x + y;
        }
    }

    public partial class Program
    {
        private static void GenericDelegateInvoke()
        {
            FormulaDelegate<int> intAddition = AddInt;
            FormulaDelegate<double> doubleAddition = AddDouble;

            Console.WriteLine("Invoking intAddition(2, 3)");
            Console.WriteLine(
                "Result = {0}", 
                intAddition(2, 3));

            Console.WriteLine("Invoking doubleAddition(2.2, 3.5)");
            Console.WriteLine(
                "Result = {0}", 
                doubleAddition(2.2, 3.5));
        }
    }
}
=======
﻿using System;

namespace GenericDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GenericDelegateInvoke();
        }
    }

    public partial class Program
    {
        private delegate T FormulaDelegate<T>(T a, T b);
    }

    public partial class Program
    {
        private static int AddInt(int x, int y)
        {
            return x + y;
        }

        private static double AddDouble(double x, double y)
        {
            return x + y;
        }
    }

    public partial class Program
    {
        private static void GenericDelegateInvoke()
        {
            FormulaDelegate<int> intAddition = AddInt;
            FormulaDelegate<double> doubleAddition = AddDouble;

            Console.WriteLine("Invoking intAddition(2, 3)");
            Console.WriteLine(
                "Result = {0}", 
                intAddition(2, 3));

            Console.WriteLine("Invoking doubleAddition(2.2, 3.5)");
            Console.WriteLine(
                "Result = {0}", 
                doubleAddition(2.2, 3.5));
        }
    }
}
>>>>>>> origin/master
