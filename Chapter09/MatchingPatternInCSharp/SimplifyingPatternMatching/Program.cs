using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplifyingPatternMatching
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            GetIntFromHexStringFunctional();
        }
    }

    public partial class Program
    {
        private static void GetIntFromHexStringFunctional()
        {
            string[] hexStrings = {
                "FF", "12CE", "F0A0", "3BD",
                "D43", "35", "0", "652F",
                "8DCC", "4125"
            };

            Console.WriteLine(
                "Invoking GetIntFromHexStringFunctional() function");

            for (int i = 0; i < hexStrings.Length; i++)
            {
                Console.WriteLine(
                    "0x{0}\t= {1}",
                    hexStrings[i],
                    HexStringToIntFunctional(
                        hexStrings[i]));
            }
        }
    }

    public partial class Program
    {
        private static void GetFactorialAggregate(int intNumber)
        {
            IEnumerable<int> ints =
                Enumerable.Range(1, intNumber);
            int factorialNumber =
                ints.Aggregate((f, s) => f * s);
            Console.WriteLine(
                "{0}! (using Aggregate) is {1}",
                intNumber,
                factorialNumber);
        }
    }

    public partial class Program
    {
        public static int HexStringToIntFunctional(
            string s)
        {
            return s.ToCharArray()
                .Reverse()
                .ToList()
                .Select((c, i) => new { c, i })
                .Sum((v) =>
                    HexCharToByteFunctional(v.c) *
                    (int)Math.Pow(0x10, v.i));
        }
    }

    public partial class Program
    {
        public static byte HexCharToByteFunctional(
            char c)
        {
            return c.Match()
                .With(ch => ch == '1', (byte)1)
                .With(ch => ch == '2', 2)
                .With(ch => ch == '3', 3)
                .With(ch => ch == '4', 4)
                .With(ch => ch == '5', 5)
                .With(ch => ch == '6', 6)
                .With(ch => ch == '7', 7)
                .With(ch => ch == '8', 8)
                .With(ch => ch == '9', 9)
                .With(ch => ch == 'A', 10)
                .With(ch => ch == 'a', 10)
                .With(ch => ch == 'B', 11)
                .With(ch => ch == 'b', 11)
                .With(ch => ch == 'C', 12)
                .With(ch => ch == 'c', 12)
                .With(ch => ch == 'D', 13)
                .With(ch => ch == 'd', 13)
                .With(ch => ch == 'E', 14)
                .With(ch => ch == 'e', 14)
                .With(ch => ch == 'F', 15)
                .With(ch => ch == 'f', 15)
                .Else(0)
                .Do();
        }
    }

    public class IncompletePatternMatchException :
        Exception
    {
    }

    public class PatternMatchOnValue<TIn, TOut>
    {
        private readonly IList<PatternMatchCase> _cases =
            new List<PatternMatchCase>();
        private readonly TIn _value;
        private Func<TIn, TOut> _elseCase;

        internal PatternMatchOnValue(TIn value)
        {
            _value = value;
        }

        public PatternMatchOnValue<TIn, TOut> With(
            Predicate<TIn> condition,
            Func<TIn, TOut> result)
        {
            _cases.Add(new PatternMatchCase
            {
                Condition = condition,
                Result = result
            });

            return this;
        }

        public PatternMatchOnValue<TIn, TOut> With(
            Predicate<TIn> condition,
            TOut result)
        {
            return With(condition, x => result);
        }

        public PatternMatchOnValue<TIn, TOut> Else(
            Func<TIn, TOut> result)
        {
            if (_elseCase != null)
            {
                throw new InvalidOperationException(
                    "Cannot have multiple else cases");
            }

            _elseCase = result;

            return this;
        }

        public PatternMatchOnValue<TIn, TOut> Else(
            TOut result)
        {
            return Else(x => result);
        }

        public TOut Do()
        {
            if (_elseCase != null)
            {
                With(x => true, _elseCase);
                _elseCase = null;
            }

            foreach (var test in _cases)
            {
                if (test.Condition(_value))
                {
                    return test.Result(_value);
                }
            }

            throw new IncompletePatternMatchException();
        }

        private struct PatternMatchCase
        {
            public Predicate<TIn> Condition;
            public Func<TIn, TOut> Result;
        }
    }

    public static class PatternMatch
    {
        public static PatternMatchContext<TIn> Match<TIn>(
            this TIn value)
        {
            return new PatternMatchContext<TIn>(value);
        }
    }

    public class PatternMatchContext<TIn>
    {
        private readonly TIn _value;

        internal PatternMatchContext(TIn value)
        {
            _value = value;
        }

        public PatternMatchOnValue<TIn, TOut> With<TOut>(
            Predicate<TIn> condition,
            TOut result)
        {
            return new PatternMatchOnValue<TIn, TOut>(_value)
                .With(condition, result);
        }
    }
}
