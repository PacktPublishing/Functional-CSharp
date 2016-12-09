using System;

namespace Palindrome
{
    public static class ExtensionMethods
    {
        public static bool IsPalindrome(this string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            string backwards = new string(array);

            return str == backwards;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = {
                "room",
                "level",
                "channel",
                "heat",
                "burn",
                "madam",
                "machine",
                "jump",
                "radar",
                "brain"
            };

            foreach (string s in strArray)
            {
                Console.WriteLine("{0} = {1}", s, s.IsPalindrome());
            }
        }
    }
}
