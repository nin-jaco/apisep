using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ApiSep.Library.Extensions
{
    public static class PredicateExtensions
    {
        public static Expression<Func<TOutT, bool>> ConvertTypeExpression<TInT, TOutT>(Expression expression) where TOutT : class
        {

            var param = Expression.Parameter(typeof(TOutT), "x");

            var result = new CustomExpVisitor<TOutT>(param).Visit(expression);

            Expression<Func<TOutT, bool>> lambda = Expression.Lambda<Func<TOutT, bool>>(result, new[] { param });

            return lambda;
        }

        private class CustomExpVisitor<T> : ExpressionVisitor
        {
            ParameterExpression _param;

            public CustomExpVisitor(ParameterExpression param)
            {
                _param = param;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _param;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.MemberType == MemberTypes.Property)
                {
                    MemberExpression memberExpression = null;

                    var memberName = node.Member.Name;
                    var otherMember = typeof(T).GetProperty(memberName);

                    memberExpression = Expression.Property(Visit(node.Expression), otherMember);

                    return memberExpression;
                }
                else
                {
                    return base.VisitMember(node);
                }
            }
        }
    }
}
