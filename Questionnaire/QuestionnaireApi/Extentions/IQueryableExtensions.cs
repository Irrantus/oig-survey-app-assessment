using Common.Enums;
using System.Linq.Expressions;

namespace QuestionnaireApi.Common
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable, string propertyOrFieldName, SortDirectionEnum direction)
        {
            var elementType = typeof(T);
            var orderByMethodName = direction == SortDirectionEnum.Ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                                                    new[] { elementType, propertyOrFieldExpression.Type }, queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
