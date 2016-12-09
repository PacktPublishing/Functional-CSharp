using System;
using System.Diagnostics;
using System.Threading;

namespace UsingThreadPool
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolProcess();
        }
    }

    public partial class Program
    {
        public static void ThreadPoolProcess()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine(
                "Start ThreadPool process now...");

            int iResult = RunInThreadPool();

            Console.WriteLine(
                "The Result = {0}",
                iResult);

            Console.WriteLine(
                "Total Time = {0} second(s)!",
                sw.ElapsedMilliseconds / 1000);
        }

        public static int RunInThreadPool()
        {
            int iResult1 = 0;

            // Assignin work LongProcess1() to idle thread 
            // in the thread pool 
            ThreadPool.QueueUserWorkItem(
                (t) =>
                    iResult1 = LongProcess1());

            // Running LongProcess2()
            int iResult2 = LongProcess2();

            // Waiting the thread to be finished
            // then returning the result
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
