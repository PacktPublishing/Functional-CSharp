using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPattern
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //TransformIntIntoText();
            GetIntFromHexString();
        }
    }

    public partial class Program
    {
        private static int GetFactorial(int intNumber)
        {
            if (intNumber == 0)
            {
                return 1;
            }

            return intNumber * GetFactorial(intNumber - 1);
        }
    }

    public partial class Program
    {
        public static void TransformIntIntoText()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                "{0} is {1}",
                i,
                NumberFactorType(i));
            }
        }
    }

    public partial class Program
    {
        public static string NumberFactorType(
            int intSelectedNumber)
        {
            if (intSelectedNumber < 2)
            {
                return "neither prime nor composite number";
            }
            else if (intSelectedNumber.IsPrime())
            {
                return "prime number";
            }
            else
            {
                return "composite number";
            }
        }
    }

    public partial class Program
    {
        private static void GetIntFromHexString()
        {
            string[] hexStrings = {
                "FF", "12CE", "F0A0", "3BD",
                "D43", "35", "0", "652F",
                "8DCC", "4125"
            };

            for (int i = 0; i < hexStrings.Length; i++)
            {
                Console.WriteLine(
                    "0x{0}\t= {1}",
                    hexStrings[i],
                    HexStringToInt(hexStrings[i]));
            }
        }
    }

    public partial class Program
    {
        public static int HexStringToInt(
            string s)
        {
            int iCnt = 0;
            int retVal = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                retVal += HexCharToByte(s[i]) * 
                    (int) Math.Pow(0x10, iCnt++);
            }

            return retVal;
        }
    }

    public partial class Program
    {
        public static byte HexCharToByte(
            char c)
        {
            byte res;

            switch (c)
            {
                case '1':
                    res = 1;
                    break;
                case '2':
                    res = 2;
                    break;
                case '3':
                    res = 3;
                    break;
                case '4':
                    res = 4;
                    break;
                case '5':
                    res = 5;
                    break;
                case '6':
                    res = 6;
                    break;
                case '7':
                    res = 7;
                    break;
                case '8':
                    res = 8;
                    break;
                case '9':
                    res = 9;
                    break;
                case 'A':
                case 'a':
                    res = 10;
                    break;
                case 'B':
                case 'b':
                    res = 11;
                    break;
                case 'C':
                case 'c':
                    res = 12;
                    break;
                case 'D':
                case 'd':
                    res = 13;
                    break;
                case 'E':
                case 'e':
                    res = 14;
                    break;
                case 'F':
                case 'f':
                    res = 15;
                    break;
                default:
                    res = 0;
                    break;
            }

            return res;
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsPrime(this int i)
        {
            if ((i % 2) == 0)
            {
                return i == 2;
            }
            int sqrt = (int)Math.Sqrt(i);
            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (i % t == 0)
                {
                    return false;
                }
            }
            return i != 1;
        }
    }

}
