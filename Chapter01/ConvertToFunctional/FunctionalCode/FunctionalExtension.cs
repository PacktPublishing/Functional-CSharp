using System;

namespace FunctionalCode
{
    public static partial class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(
            this TSource @this,
            Func<TSource, TResult> fn) =>
                fn(@this);
    }

    public static partial class FunctionalExtensions
    {
        public static T Tee<T>(
            this T @this,
            Action<T> action)
        {
            action(@this);
            return @this;
        }
    }
}