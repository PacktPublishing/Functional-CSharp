using System;

namespace PiggybackNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 60;
            Console.WriteLine(i.Square());
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