<<<<<<< HEAD
﻿using System;

namespace SimpleDelegates
{
    public partial class Program
    {
        private delegate int AreaCalculatorDelegate(int x, int y);
    }

    public partial class Program
    {
        static void Main(string[] args)
        {
            AreaCalculatorDelegate rect = Rectangle;
            AreaCalculatorDelegate sqr = Square;

            int i = rect(1, 2);
            int j = sqr(2, 3);

            Console.WriteLine("i = " + i);
            Console.WriteLine("j = " + j);
        }
    }

    public partial class Program
    {
        static int Rectangle(int a, int b)
        {
            return a * b;
        }
    }

    public partial class Program
    {
        static int Square(int x, int y)
        {
            return x * y;
        }
    }

}
=======
﻿using System;

namespace SimpleDelegates
{
    public partial class Program
    {
        private delegate int AreaCalculatorDelegate(int x, int y);
    }

    public partial class Program
    {
        static void Main(string[] args)
        {
            AreaCalculatorDelegate rect = Rectangle;
            AreaCalculatorDelegate sqr = Square;

            int i = rect(1, 2);
            int j = sqr(2, 3);

            Console.WriteLine("i = " + i);
            Console.WriteLine("j = " + j);
        }
    }

    public partial class Program
    {
        static int Rectangle(int a, int b)
        {
            return a * b;
        }
    }

    public partial class Program
    {
        static int Square(int x, int y)
        {
            return x * y;
        }
    }

}
>>>>>>> origin/master
