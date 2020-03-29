using System;
using System.Collections.Generic;

namespace ApiSep.Library.Helpers
{
    public class GenericEqualityComparer<T, T2> : IEqualityComparer<T>
    {
        private Func<T, T2> Property;
        private Func<T, int> HashCode;

        public GenericEqualityComparer(Func<T, T2> property, Func<T, int> hashCode)
        {
            Property = property;
            HashCode = hashCode;
        }

        public bool Equals(T x, T y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            var identifierX = Property(x);
            var identifierY = Property(y);

            if (identifierX == null && identifierY == null)
            {
                return true;
            }

            if (identifierX == null || identifierY == null)
            {
                return false;
            }

            return identifierX.Equals(identifierY);
        }

        public int GetHashCode(T obj)
        {
            if (obj == null)
            {
                return 0;
            }

            var hash = HashCode(obj);
            return hash;
        }
    }
}
