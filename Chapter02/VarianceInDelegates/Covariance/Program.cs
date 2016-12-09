<<<<<<< HEAD
﻿using System;
using System.IO;

namespace Covariance
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //CovarianceStreamWriterInvoke();
            CovarianceStringWriterInvoke();
        }
    }

    public partial class Program
    {
        private delegate TextWriter CovarianceDelegate();
    }

    public partial class Program
    {
        private static StreamWriter StreamWriterMethod()
        {
            DirectoryInfo[] arrDirs = 
                new DirectoryInfo(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ProgramFilesX86) +
                    @"\Microsoft Visual Studio 14.0")
                    .GetDirectories();

            StreamWriter sw = new StreamWriter(
                Console.OpenStandardOutput());

            foreach (DirectoryInfo dir in arrDirs)
            {
                sw.WriteLine(dir.Name);
            }

            return sw;
        }
    }

    public partial class Program
    {
        private static void CovarianceStreamWriterInvoke()
        {
            CovarianceDelegate covDelegate;

            Console.WriteLine(
                "Invoking CovarianceStreamWriterInvoke method:");
            covDelegate = StreamWriterMethod;
            StreamWriter sw = (StreamWriter)covDelegate();
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }
    }

    public partial class Program
    {
        private static StringWriter StringWriterMethod()
        {
            StringWriter strWriter = new StringWriter();

            string[] arrString = new string[]{
                "Covariance",
                "example",
                "using",
                "StringWriter",
                "object"
            };

            foreach (string str in arrString)
            {
                strWriter.Write(str);
                strWriter.Write(' ');
            }

            return strWriter;
        }
    }

    public partial class Program
    {
        private static void CovarianceStringWriterInvoke()
        {
            CovarianceDelegate covDelegate;

            Console.WriteLine(
                "Invoking CovarianceStringWriterInvoke method:");
            covDelegate = StringWriterMethod;
            StringWriter strW = (StringWriter)covDelegate();
            Console.WriteLine(strW.ToString());
        }
    }
}
=======
﻿using System;
using System.IO;

namespace Covariance
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //CovarianceStreamWriterInvoke();
            CovarianceStringWriterInvoke();
        }
    }

    public partial class Program
    {
        private delegate TextWriter CovarianceDelegate();
    }

    public partial class Program
    {
        private static StreamWriter StreamWriterMethod()
        {
            DirectoryInfo[] arrDirs = 
                new DirectoryInfo(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ProgramFilesX86) +
                    @"\Microsoft Visual Studio 14.0")
                    .GetDirectories();

            StreamWriter sw = new StreamWriter(
                Console.OpenStandardOutput());

            foreach (DirectoryInfo dir in arrDirs)
            {
                sw.WriteLine(dir.Name);
            }

            return sw;
        }
    }

    public partial class Program
    {
        private static void CovarianceStreamWriterInvoke()
        {
            CovarianceDelegate covDelegate;

            Console.WriteLine(
                "Invoking CovarianceStreamWriterInvoke method:");
            covDelegate = StreamWriterMethod;
            StreamWriter sw = (StreamWriter)covDelegate();
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }
    }

    public partial class Program
    {
        private static StringWriter StringWriterMethod()
        {
            StringWriter strWriter = new StringWriter();

            string[] arrString = new string[]{
                "Covariance",
                "example",
                "using",
                "StringWriter",
                "object"
            };

            foreach (string str in arrString)
            {
                strWriter.Write(str);
                strWriter.Write(' ');
            }

            return strWriter;
        }
    }

    public partial class Program
    {
        private static void CovarianceStringWriterInvoke()
        {
            CovarianceDelegate covDelegate;

            Console.WriteLine(
                "Invoking CovarianceStringWriterInvoke method:");
            covDelegate = StringWriterMethod;
            StringWriter strW = (StringWriter)covDelegate();
            Console.WriteLine(strW.ToString());
        }
    }
}
>>>>>>> origin/master
