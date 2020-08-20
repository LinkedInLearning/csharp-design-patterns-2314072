using System;
using System.Collections.Generic;
namespace HPlusSports.Core
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> FilterdSelect<T, TResult>(this IEnumerable<T> enumerable, Func<T, bool> filter, Func<T, TResult> fieldSelector)
        {
            foreach (var a in enumerable)
                if (filter(a)) yield return fieldSelector(a);            
        }
    }
}