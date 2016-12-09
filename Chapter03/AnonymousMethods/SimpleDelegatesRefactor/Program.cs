<<<<<<< HEAD
﻿using System;

namespace SimpleDelegatesRefactor
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            int i = AreaRectangleDelegate(1, 2);
            int j = AreaSquareDelegate(2, 3);

            Console.WriteLine("i = " + i);
            Console.WriteLine("j = " + j);
        }
    }

    public partial class Program
    {
        private static Func<int, int, int> AreaRectangleDelegate =
            delegate (int a, int b)
            {
                return a * b;
            };

        private static Func<int, int, int> AreaSquareDelegate =
            delegate (int x, int y)
            {
                return x * y;
            };
    }
}
=======
﻿using System;

namespace SimpleDelegatesRefactor
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            int i = AreaRectangleDelegate(1, 2);
            int j = AreaSquareDelegate(2, 3);

            Console.WriteLine("i = " + i);
            Console.WriteLine("j = " + j);
        }
    }

    public partial class Program
    {
        private static Func<int, int, int> AreaRectangleDelegate =
            delegate (int a, int b)
            {
                return a * b;
            };

        private static Func<int, int, int> AreaSquareDelegate =
            delegate (int x, int y)
            {
                return x * y;
            };
    }
}
>>>>>>> origin/master
