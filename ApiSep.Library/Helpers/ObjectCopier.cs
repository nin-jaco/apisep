using System;
using System.Linq.Expressions;

namespace ApiSep.Library.Helpers
{
    public class ObjectCopier
    {

        /// <summary>
        /// Copy the value from the sources property value if the targets property value is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="property"></param>
        public static void CopyIfEmpty<T>(T source, T target, Expression<Func<T, string>> property)
        {
            var getter = ExpressionUtils.CreateGetter(property);
            var setter = ExpressionUtils.CreateSetter(property);

            var str1 = getter(target);
            var str2 = getter(source);

            if (String.IsNullOrEmpty(str1) && !String.IsNullOrEmpty(str2))
            {
                setter(target, str2);
            }
        }

        /// <summary>
        /// Copy the value from the sources property value if the targets property value is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="property"></param>
        public static void CopyIfEmpty<T, TR>(T source, T target, Expression<Func<T, TR?>> property) where T : class where TR : struct
        {
            var getter = ExpressionUtils.CreateGetter(property);
            var setter = ExpressionUtils.CreateSetter(property);

            var val1 = getter(target);
            var val2 = getter(source);

            if (val1 == null && val2 != null)
            {
                setter(target, val2);
            }
        }
    }
}
