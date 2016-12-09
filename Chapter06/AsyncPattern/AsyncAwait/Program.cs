using System;
using System.IO;

namespace AsyncAwait
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            AsyncAwaitReadFile();
        }
    }

    public partial class Program
    {
        static bool IsFinish;

        public static void AsyncAwaitReadFile()
        {
            IsFinish = false;

            ReadFileAsync();

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!IsFinish);

            Console.WriteLine("End of AsyncAwaitReadFile() method");
        }

        public static async void ReadFileAsync()
        {
            FileStream fs =
                File.OpenRead(
                    @"..\..\..\LoremIpsum.txt");
            byte[] buffer = new byte[fs.Length];
            int totalBytes =
                await fs.ReadAsync(
                    buffer, 
                    0, 
                    (int)fs.Length);
            Console.WriteLine("Read {0} bytes.", totalBytes);

            IsFinish = true;
            fs.Dispose();
        }
    }
}
