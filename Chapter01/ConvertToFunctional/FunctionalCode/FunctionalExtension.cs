using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
