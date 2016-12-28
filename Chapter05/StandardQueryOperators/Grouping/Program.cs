using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grouping
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //GroupingByFileNameExtension();
            GroupingByInto();
        }
    }

    public partial class Program
    {
        public static void GroupingByFileNameExtension()
        {
            IEnumerable<string> fileList =
                Directory.EnumerateFiles(
                    @"G:\packages", "*.*",
                    SearchOption.AllDirectories);

            //IEnumerable<IGrouping<string, string>> query =
            //    fileList.GroupBy(f => 
            //        Path.GetFileName(f)[0].ToString());

            IEnumerable<IGrouping<string, string>> query =
                from f in fileList
                group f by Path.GetFileName(f)[0].ToString();

            foreach (IGrouping<string, string> g in query)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "File start with the letter: " +
                    g.Key);
                foreach (string filename in g)
                    Console.WriteLine(
                        "..." + Path.GetFileName(filename));
            }
        }
    }

    public partial class Program
    {
        public static void GroupingByInto()
        {
            IEnumerable<string> fileList =
                Directory.EnumerateFiles(
                    @"G:\packages", "*.*",
                    SearchOption.AllDirectories);

            IEnumerable<IGrouping<string, string>> query =
                from f in fileList
                group f
                    by Path.GetFileName(f)[0].ToString()
                    into g
                orderby g.Key
                select g;

            foreach (IGrouping<string, string> g in query)
            {
                Console.WriteLine(
                    "File start with the letter: " +
                    g.Key);
                //foreach (string filename in g)
                //    Console.WriteLine(
                //        "..." + Path.GetFileName(filename));
            }
        }
    }
}
