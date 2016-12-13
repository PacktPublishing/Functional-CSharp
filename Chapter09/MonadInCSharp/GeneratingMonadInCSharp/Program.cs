using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingMonadInCSharp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            RunMultipliedByTwo();
        }
    }

    public partial class Program
    {
        private static Nullable<int> MultipliedByTwoFunction(
            Nullable<int> iNullable,
            Func<int, int> funcDelegate)
        {
            if (iNullable.HasValue)
            {
                int unWrappedInt =
                    iNullable.Value;
                int multipliedByTwo =
                    funcDelegate(unWrappedInt);
                return new Nullable<int>(
                    multipliedByTwo);
            }
            else
            {
                return new Nullable<int>();
            }
        }
    }

    public partial class Program
    {
        private static Nullable<int> MultipliedByTwo(
            Nullable<int> iNullable)
        {
            return MultipliedByTwoFunction(
                iNullable,
                (int x) =>
                    x * 2);
        }
    }

    public partial class Program
    {
        private static void RunMultipliedByTwo()
        {
            Console.WriteLine(
                "RunMultipliedByTwo() implementing " +
                "higher-order programming");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(
                    "{0} multiplied by to is equal to {1}",
                    i,
                    MultipliedByTwo(i));
            }
        }
    }

    public partial class Program
    {
        private static Nullable<T> MultipliedByTwoFunction<T>(
            Nullable<T> iNullable,
            Func<T, T> funcDelegate) 
                where T : struct
        {
            if (iNullable.HasValue)
            {
                T unWrappedInt = 
                    iNullable.Value;
                T multipliedByTwo = 
                    funcDelegate(unWrappedInt);
                return new Nullable<T>(
                    multipliedByTwo);
            }
            else
            {
                return new Nullable<T>();
            }
        }
    }

    public partial class Program
    {
        private static Nullable<R> MultipliedByTwoFunction<V, R>(
            Nullable<V> iNullable,
            Func<V, R> funcDelegate)
                where V : struct
                where R : struct
        {
            if (iNullable.HasValue)
            {
                V unWrappedInt =
                    iNullable.Value;
                R multipliedByTwo =
                    funcDelegate(unWrappedInt);
                return new Nullable<R>(
                    multipliedByTwo);
            }
            else
            {
                return new Nullable<R>();
            }
        }
    }

    public partial class Program
    {
        static Lazy<R> MultipliedByTwoFunction<V, R>(
            Lazy<V> lazy,
            Func<V, R> function)
                where V : struct
                where R : struct
        {
            return new Lazy<R>(() =>
            {
                V unWrappedInt = 
                    lazy.Value;
                R multipliedByTwo = 
                    function(unWrappedInt);
                return multipliedByTwo;
            });
        }
    }

    //public partial class Program
    //{
    //    private static M<R> MonadFunction<V, R>(
    //        M<V> amplified,
    //        Func<V, R> function)
    //    {
    //        // Implementation
    //    }
    //}

    public partial class Program
    {
        private static Nullable<R> 
            MultipliedByTwoFunctionSpecial<V, R>(
                Nullable<V> nullable,
                Func<V, Nullable<R>> function)
                    where V : struct
                    where R : struct
        {
            if (nullable.HasValue)
            {
                V unWrappedInt = 
                    nullable.Value;
                Nullable<R> multipliedByTwo = 
                    function(unWrappedInt);
                return multipliedByTwo;
            }
            else
            {
                return new Nullable<R>();
            }
        }
    }

    public partial class Program
    {
        private static Func<R>
            MultipliedByTwoFunctionSpecial<V, R>(
                Func<V> funcDelegate,
                Func<V, Func<R>> function)
        {
            return () =>
            {
                V unwrappedValue =
                    funcDelegate();
                Func<R> resultValue =
                    function(unwrappedValue);
                return resultValue();
            };
        }
    }

    public partial class Program
    {
        private static Lazy<R> 
            MultipliedByTwoFunctionSpecial<V, R>(
                Lazy<V> lazy,
                Func<V, Lazy<R>> function)
        {
            return new Lazy<R>(() =>
            {
                V unwrappedValue = 
                    lazy.Value;
                Lazy<R> resultValue = 
                    function(unwrappedValue);
                return resultValue.Value;
            });
        }

        private static async Task<R> 
            MultipliedByTwoFunctionSpecial<V, R>(
                Task<V> task,
                Func<V, Task<R>> function)
        {
            V unwrappedValue = 
                await task;
            Task<R> resultValue = 
                function(unwrappedValue);
            return await resultValue;
        }
    }

    public partial class Program
    {
        static IEnumerable<R>
            MultipliedByTwoFunctionSpecial<V, R>(
                IEnumerable<V> sequence,
                Func<V, IEnumerable<R>> function)
        {
            foreach (V unwrappedValue in sequence)
            {
                IEnumerable<R> resultValue = 
                    function(unwrappedValue);
                foreach (R r in resultValue)
                    yield return r;
            }
        }
    }
}
