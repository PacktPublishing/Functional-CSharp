using System;
using System.IO;

namespace APM
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ReadFile();
            //ReadAsyncFile();
            ReadAsyncFileAnonymousMethod();
        }
    }

    public partial class Program
    {
        public static void ReadFile()
        {
            FileStream fs =
                File.OpenRead(
                    @"..\..\..\LoremIpsum.txt");
            byte[] buffer = new byte[fs.Length];
            int totalBytes =
                fs.Read(buffer, 0, (int)fs.Length);
            Console.WriteLine("Read {0} bytes.", totalBytes);
            fs.Dispose();
        }
    }

    public partial class Program
    {
        public static void ReadAsyncFile()
        {
            FileStream fs =
                File.OpenRead(
                    @"..\..\..\LoremIpsum.txt");
            byte[] buffer = new byte[fs.Length];
            IAsyncResult result =
                fs.BeginRead(
                    buffer, 0, (int)fs.Length, OnReadComplete, fs);

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!result.IsCompleted);

            fs.Dispose();
        }

        private static void OnReadComplete(IAsyncResult result)
        {
            FileStream fStream =
                (FileStream)result.AsyncState;
            int totalBytes =
                fStream.EndRead(result);
            Console.WriteLine(
                "Read {0} bytes.", totalBytes);
            fStream.Dispose();
        }
    }

    public partial class Program
    {
        public static void ReadAsyncFileAnonymousMethod()
        {
            FileStream fs =
                File.OpenRead(
                    @"..\..\..\LoremIpsum.txt");
            byte[] buffer = new byte[fs.Length];
            IAsyncResult result =
                fs.BeginRead(
                    buffer,
                    0,
                    (int)fs.Length,
                    asyncResult =>
                    {
                        int totalBytes =
                            fs.EndRead(
                                asyncResult);
                        Console.WriteLine(
                            "Read {0} bytes.", totalBytes);
                    },
                    null);

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!result.IsCompleted);

            fs.Dispose();
        }
    }
}
