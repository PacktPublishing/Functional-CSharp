using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LazyEnumeration
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GetFibonnacciNumbers(40);
        }
    }

    public partial class Program
    {
        private static void GetFibonnacciNumbers(
            int totalNumber)
        {
            FibonacciNumbers fibNumbers =
                new FibonacciNumbers();

            foreach (Int64 number in
                fibNumbers.Take(totalNumber))
            {
                Console.Write(number);
                Console.Write("\t");
            }

            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public class FibonacciNumbers
            : IEnumerable<Int64>
        {
            public IEnumerator<Int64> GetEnumerator()
            {
                return new FibEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

    public partial class Program
    {
        public class FibEnumerator
            : IEnumerator<Int64>
        {
            public FibEnumerator()
            {
                Reset();
            }

            // To get the current element
            public Int64 Current { get; private set; }

            // To get the last element
            Int64 Last { get; set; }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                ; // Do Nothing
            }

            public bool MoveNext()
            {
                if (Current == -1)
                {
                    // Fibonacci algorithm
                    // F0 = 0
                    Current = 0;
                }
                else if (Current == 0)
                {
                    // Fibonacci algorithm
                    // F1 = 1
                    Current = 1;
                }
                else
                {
                    // Fibonacci algorithm
                    // Fn = F(n-1) + F(n-2)
                    Int64 next = Current + Last;
                    Last = Current;
                    Current = next;
                }

                // It's never ending sequence, 
                // so the MoveNext() always TRUE
                return true;
            }

            public void Reset()
            {
                // Back to before first element
                // which is -1
                Current = -1;
            }
        }
    }
}
