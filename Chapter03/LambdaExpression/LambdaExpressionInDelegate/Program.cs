﻿using System;

namespace LambdaExpressionInDelegate
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
            (a, b) => a * b;

        private static Func<int, int, int> AreaSquareDelegate =
            (x, y) => x * y;
    }
}
