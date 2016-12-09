using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiggybackNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int ii = 10;
            Console.WriteLine(ii.Square());
        }
    }
}

namespace System
{
    public static class ExtensionMethod
    {
        public static int Square(this int i)
        {
            return i * i;
        }
    }
}