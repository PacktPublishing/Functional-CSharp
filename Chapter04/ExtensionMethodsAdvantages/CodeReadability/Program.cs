using System;

namespace CodeReadability
{
    public class Program
    {
        static string[] sentences = new string[]
        {
            " h o w ",
            " t o ",
            " a p p l y ",
            " e x t e n s i o n ",
            " m e t h o d s ",
            " i n ",
            " c s h a r p ",
            " p r o g r a m m i n g "
        };

        static void Main(string[] args)
        {
            //// Using HelperMethods
            //string sntc = "";
            //foreach (string str in sentences)
            //{
            //    string strTemp = str;
            //    strTemp = HelperMethods.TrimAllSpace(strTemp);
            //    strTemp = HelperMethods.Capitalize(strTemp);
            //    sntc += strTemp + " ";
            //}

            //Console.WriteLine(sntc.Trim());

            // Using extension Methods
            string sntc = "";
            foreach (string str in sentences)
            {
                sntc += str.TrimAllSpace().Capitalize() + " ";
            }

            Console.WriteLine(sntc.Trim());
        }
    }
}
