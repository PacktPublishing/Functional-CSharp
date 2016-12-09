using System;

namespace ReferencingNamespaceLib
{
    public static class ExtensionMethodsClass
    {
        public static byte[] ConvertToHex(this string str)
        {
            int i = 0;
            byte[] HexArray = new byte[str.Length];

            foreach (char ch in str)
            {
                HexArray[i++] = Convert.ToByte(ch);
            }

            return HexArray;
        }
    }
}
