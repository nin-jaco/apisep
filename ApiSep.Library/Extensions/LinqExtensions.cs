using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiSep.Library.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Distinct<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> selector)
        {
            return source.Distinct(new LambdaEqualityComparer<TSource, TCompare>(selector));
        }

        /* usage
         * var dates = new List<DateTime>() { // ... }
         * var distinctYears = dates.Distinct(date => date.Year);
        */

        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }
    }
}
