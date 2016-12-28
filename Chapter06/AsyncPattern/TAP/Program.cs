using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TAP
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ReadFileTask();
            //ReadTwoFileTask();
            ReadTwoFileTaskWithCancellation();
            //WrapApmIntoTap();
        }
    }

    public partial class Program
    {
        public static void ReadFileTask()
        {
            bool IsFinish = false;

            FileStream fs =
                File.OpenRead(
                    @"..\..\..\LoremIpsum.txt");
            byte[] readBuffer = new byte[fs.Length];
            fs.ReadAsync(
                readBuffer,
                0,
                (int)fs.Length)
                .ContinueWith(task =>
                {
                    if (task.Status ==
                        TaskStatus.RanToCompletion)
                    {
                        IsFinish = true;
                        Console.WriteLine(
                            "Read {0} bytes.",
                            task.Result);
                    }

                    fs.Dispose();
                });

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!IsFinish);

            Console.WriteLine("End of ReadFileTask() method");
        }
    }

    public partial class Program
    {
        public static void ReadTwoFileTask()
        {
            bool IsFinish = false;

            Task readFile1 =
                ReadFileAsync(
                    @"..\..\..\LoremIpsum.txt");
            Task readFile2 =
                ReadFileAsync(
                    @"..\..\..\LoremIpsum2.txt");

            Task.WhenAll(readFile1, readFile2)
                .ContinueWith(task =>
                {
                    IsFinish = true;
                    Console.WriteLine(
                        "All files have been read successfully.");
                });

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!IsFinish);

            Console.WriteLine("End of ReadTwoFileTask() method");
        }

        //public static Task<int> ReadFileAsync(string filePath)
        //{
        //    FileStream fs = File.OpenRead(filePath);
        //    byte[] readBuffer = new byte[fs.Length];
        //    Task<int> readTask =
        //        fs.ReadAsync(
        //            readBuffer,
        //            0,
        //            (int)fs.Length);
        //    readTask.ContinueWith(task =>
        //    {
        //        if (task.Status == TaskStatus.RanToCompletion)
        //            Console.WriteLine(
        //                "Read {0} bytes from file {1}",
        //                task.Result,
        //                filePath);

        //        fs.Dispose();
        //    });

        //    return readTask;
        //}
    }

    public partial class Program
    {
        public static void ReadTwoFileTaskWithCancellation()
        {
            bool IsFinish = false;

            // Define the cancellation token.
            CancellationTokenSource source =
                new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task readFile1 =
                ReadFileAsync(
                    @"..\..\..\LoremIpsum.txt");
            Task readFile2 =
                ReadFileAsync(
                    @"..\..\..\LoremIpsum2.txt");

            Task.WhenAll(readFile1, readFile2)
                .ContinueWith(task =>
                {
                    IsFinish = true;
                    Console.WriteLine(
                        "All files have been read successfully.");
                }
                , token
                );

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
                if (i > 10)
                {
                    source.Cancel();
                    Console.WriteLine(
                        "All tasks are cancelled at i = " +
                        i);
                    break;
                }
            }
            while (!IsFinish);

            Console.WriteLine(
                "End of ReadTwoFileTaskWithCancellation() method");
        }
    }

    public partial class Program
    {
        public static bool IsFinish;

        public static void WrapApmIntoTap()
        {
            IsFinish = false;

            ReadFileAsync(
                @"..\..\..\LoremIpsum.txt");

            //do other work while file is read
            int i = 0;
            do
            {
                Console.WriteLine("Timer Counter: {0}", ++i);
            }
            while (!IsFinish);

            Console.WriteLine(
                "End of WrapApmIntoTap() method");
        }

        private static Task<int> ReadFileAsync(string filePath)
        {
            FileStream fs = File.OpenRead(filePath);
            byte[] readBuffer = new Byte[fs.Length];
            Task<int> readTask =
                Task.Factory.FromAsync(
                    (Func<byte[],
                        int,
                        int,
                        AsyncCallback,
                        object,
                        IAsyncResult>)
                            fs.BeginRead,
                    (Func<IAsyncResult, int>)
                        fs.EndRead,
                    readBuffer,
                    0,
                    (int)fs.Length,
                    null);

            readTask.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    IsFinish = true;
                    Console.WriteLine(
                        "Read {0} bytes from file {1}",
                        task.Result,
                        filePath);
                }

                fs.Dispose();
            });

            return readTask;
        }
    }
}
