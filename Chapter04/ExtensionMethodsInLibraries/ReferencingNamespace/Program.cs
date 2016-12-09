using System;
using ReferencingNamespaceLib;

namespace ReferencingNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string strData = "Functional in C#";
            byte[] byteData = strData.ConvertToHex();
            foreach (char c in strData)
            {
                Console.WriteLine("{0} = 0x{1:X2} ({2})",
                    c.ToString(),
                    byteData[i],
                    byteData[i++]);
            }
        }
    }
}
