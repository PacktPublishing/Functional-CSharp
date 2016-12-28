using System;

namespace AmplifiedFuncType
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
        Func<int> MultipliedFunc;
    }

    public partial class Program
    {
        private static void RunMultipliedByTwoFunc()
        {
            Func<int> intFunc = MultipliedByTwo(
                () => 1 + 1);
        }
    }

    public partial class Program
    {
        private static void RunMultipliedByTwo()
        {
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
        private static Nullable<int> MultipliedByTwo(
            Nullable<int> nullableInt)
        {
            if (nullableInt.HasValue)
            {
                int unWrappedInt =
                    nullableInt.Value;
                int multipliedByTwo =
                    unWrappedInt * 2;
                return GetNullableFromInt(
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
        private static Nullable<int> GetNullableFromInt(
            int iNumber)
        {
            return new Nullable<int>(
                iNumber);
        }
    }

    public partial class Program
    {
        private static Func<int> GetFuncFromInt(
            int iItem)
        {
            return () => iItem;
        }
    }

    public partial class Program
    {
        private static Func<int> MultipliedByTwo(
            Func<int> funcDelegate)
        {
            int unWrappedFunc =
                funcDelegate();
            int multipliedByTwo =
                unWrappedFunc * 2;
            return GetFuncFromInt(
                multipliedByTwo);
        }
    }

    public partial class Program
    {
        private static Func<int> MultipliedByTwoFunction(
            Func<int> funcDelegate)
        {
            return () =>
            {
                int unWrappedFunc =
                    funcDelegate();
                int multipliedByTwo =
                    unWrappedFunc * 2;
                return multipliedByTwo;
            };
        }
    }
}
