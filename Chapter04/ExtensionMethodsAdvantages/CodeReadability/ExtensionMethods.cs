using System.Linq;

namespace CodeReadability
{
    public static class ExtensionMethods
    {
        public static string TrimAllSpace(this string str)
        {
            string retValue = "";

            foreach (char c in str)
            {
                retValue +=
                    !char.IsWhiteSpace(c) ?
                    c.ToString() :
                    "";
            }

            return retValue;
        }

        public static string Capitalize(this string str)
        {
            string retValue = "";
            string[] allWords = str.Split(' ');

            foreach (string s in allWords)
            {
                retValue += s.First()
                    .ToString()
                    .ToUpper()
                    + s.Substring(1)
                    + " ";
            }

            return retValue.Trim();
        }
    }
}