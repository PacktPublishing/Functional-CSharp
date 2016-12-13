using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmplifierOfTypes
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //PrintIntContainingNull();
            AmplifyString();
        }
    }

    public partial class Program
    {
        private static Nullable<int> WordToNumber(string word)
        {
            Nullable<int> returnValue;

            if (word == null)
            {
                return null;
            }

            switch (word.ToLower())
            {
                case "zero":
                    returnValue = 0;
                    break;
                case "one":
                    returnValue = 1;
                    break;
                case "two":
                    returnValue = 2;
                    break;
                case "three":
                    returnValue = 3;
                    break;
                case "four":
                    returnValue = 4;
                    break;
                case "five":
                    returnValue = 5;
                    break;
                default:
                    returnValue = null;
                    break;
            }

            return returnValue;
        }
    }

    public partial class Program
    {
        private static void PrintStringNumber(
            string stringNumber)
        {
            if (stringNumber == null &&
                WordToNumber(stringNumber) == null)
            {
                Console.WriteLine(
                    "Word: null is Int: null");
            }
            else
            {
                Console.WriteLine(
                    "Word: {0} is Int: {1}",
                    stringNumber.ToString(),
                    WordToNumber(stringNumber));
            }
        }
    }

    public partial class Program
    {
        private static void PrintIntContainingNull()
        {
            PrintStringNumber("three");
            PrintStringNumber("five");
            PrintStringNumber(null);
            PrintStringNumber("zero");
            PrintStringNumber("four");
        }
    }

    public partial class Program
    {
        private static void AmplifyString()
        {
            IEnumerable<string> stringEnumerable
                = YieldNames();

            Console.WriteLine(
                "Enumerate the stringEnumerable");

            foreach (string s in stringEnumerable)
            {
                Console.WriteLine(
                    "- {0}",
                    s);
            }

            IEnumerable<string> stringSorted = 
                SortAscending(stringEnumerable);

            Console.WriteLine();

            Console.WriteLine(
                "Sort the stringEnumerable");

            foreach (string s in stringSorted)
            {
                Console.WriteLine(
                    "- {0}",
                    s);
            }
        }
    }

    public partial class Program
    {
        private static IEnumerable<string> YieldNames()
        {
            yield return "Nicholas Shaw";
            yield return "Anthony Hammond";
            yield return "Desiree Waller";
            yield return "Gloria Allen";
            yield return "Daniel McPherson";
        }
    }

    public partial class Program
    {
        private static IEnumerable<string> SortAscending(
            IEnumerable<string> enumString)
        {
            return enumString.OrderBy(s => s);
        }
    }
}
