using System;
using System.Diagnostics;
using System.Threading;

namespace ApplyingThreads
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            AsynchronousProcess();
        }
    }

    public partial class Program
    {
        public static void AsynchronousProcess()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine(
                "Start asynchronous process now...");

            int iResult = RunAsynchronousProcess();

            Console.WriteLine(
                 "The Result = {0}",
                 iResult);

            Console.WriteLine(
                "Total Time = {0} second(s)!",
                sw.ElapsedMilliseconds / 1000);
        }

        public static int RunAsynchronousProcess()
        {
            int iResult1 = 0;

            // Creating thread for LongProcess1()
            Thread thread = new Thread(
                () =>
                    iResult1 = LongProcess1());

            // Starting the thread
            thread.Start();

            // Running LongProcess2()
            int iResult2 = LongProcess2();

            // Waiting for the thread to finish
            thread.Join();

            // Return the the total result
            return iResult1 + iResult2;
        }

        public static int LongProcess1()
        {
            Thread.Sleep(5000);
            return 5;
        }

        public static int LongProcess2()
        {
            Thread.Sleep(7000);
            return 7;
        }
    }
}