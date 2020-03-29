using System;
using System.Collections.Generic;

namespace ApiSep.Library.Extensions
{
    public class LambdaEqualityComparer<TSource, TDest> :
    IEqualityComparer<TSource>
    {
        public Func<TSource, TDest> Selector { get; set; }

        public LambdaEqualityComparer(Func<TSource, TDest> selector)
        {
            Selector = selector;
        }

        public bool Equals(TSource obj, TSource other)
        {
            return Selector(obj).Equals(Selector(other));
        }

        public int GetHashCode(TSource obj)
        {
            return Selector(obj).GetHashCode();
        }
    }
}
