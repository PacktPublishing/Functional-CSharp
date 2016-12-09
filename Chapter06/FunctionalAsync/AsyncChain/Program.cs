using System;
using System.Threading.Tasks;

namespace AsyncChain
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            AsyncChain();
        }
    }

    public partial class Program
    {
        public async static Task<int> FunctionA(
            int a) => await Task.FromResult(a * 1);
        public async static Task<int> FunctionB(
            int b) => await Task.FromResult(b * 2);
        public async static Task<int> FunctionC(
            int c) => await Task.FromResult(c * 3);

        public async static void AsyncChain()
        {
            int i = await FunctionC(10)
                .MapAsync(FunctionB)
                .MapAsync(FunctionA);

            Console.WriteLine("The result = {0}", i);
        }
    }

    public static class ExtensionMethod
    {
        public static async Task<TResult> MapAsync<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this);
    }
}
