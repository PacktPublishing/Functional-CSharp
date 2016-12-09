using System;

namespace NonPureFunction1
{
    class Program
    {
        private static string strValue = "First";

        public static void AddSpace(string str)
        {
            strValue += ' ' + str;
        }

        static void Main(string[] args)
        {
            AddSpace("Second");
            AddSpace("Third");
            Console.WriteLine(strValue);
        }

    }
}
