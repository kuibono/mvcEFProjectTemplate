using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    public static class DynamicLinqExtension
    {
        public static object Sum(this IQueryable source, string member)
        {
            try
            {
                return doSummary(source, member, "Sum");
            }
            catch
            {
                return 0;
            }
        }
        public static object Average(this IQueryable source, string member)
        {
            try
            {
                return doSummary(source, member, "Average");
            }
            catch
            {
                return 0;
            }
        }
        public static object Max(this IQueryable source, string member)
        {
            try
            {
                return doSummary(source, member, "Max");
            }
            catch
            {
                return 0;
            }
        }
        public static object Min(this IQueryable source, string member)
        {
            try
            {
                return doSummary(source, member, "Max");
            }
            catch
            {
                return 0;
            }
        }


        private static object doSummary(this IQueryable source, string member, string methodName)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (member == null) throw new ArgumentNullException("member");

            // Properties
            PropertyInfo property = source.ElementType.GetProperty(member);
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "s");
            Expression selector = Expression.Lambda(Expression.MakeMemberAccess(parameter, property), parameter);
            // We've tried to find an expression of the type Expression<Func<TSource, TAcc>>,
            // which is expressed as ( (TSource s) => s.Price );

            // Method
            MethodInfo sumMethod = typeof(Queryable).GetMethods().First(
                m => m.Name == methodName
                    && m.ReturnType == property.PropertyType // should match the type of the property
                    && m.IsGenericMethod);

            return source.Provider.Execute(
                Expression.Call(
                    null,
                    sumMethod.MakeGenericMethod(new[] { source.ElementType }),
                    new[] { source.Expression, Expression.Quote(selector) }));
        }
    }
}
