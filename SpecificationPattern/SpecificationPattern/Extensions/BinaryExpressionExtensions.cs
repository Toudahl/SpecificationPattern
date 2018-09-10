using System;
using System.Linq.Expressions;

namespace Morts.SpecificationPattern.Extensions
{
	static class BinaryExpressionExtensions
	{
		public static Expression<Func<T, bool>> ToLambda<T>(this BinaryExpression binaryExpression)
		{
			var parameterExpression = Expression.Parameter(typeof(T));

			var expression = new ParameterReplacer(parameterExpression).Visit(binaryExpression);

			return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
		}



		private class ParameterReplacer : ExpressionVisitor
		{
			private readonly ParameterExpression _parameter;

			protected override Expression VisitParameter(ParameterExpression node)
			{
				return _parameter;
			}

			internal ParameterReplacer(ParameterExpression parameter)
			{
				_parameter = parameter;
			}
		}
	}
}
