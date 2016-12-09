using System;

namespace PureFunction
{
    class Program
    {
        public static string AddSpace(string strSource, string str)
        {
            return (strSource + ' ' + str);
        }

        static void Main(string[] args)
        {
            string str1 = "First";
            string str2 = AddSpace(str1, "Second");
            string str3 = AddSpace(str2, "Third");
            Console.WriteLine(str3);
        }
    }
}
