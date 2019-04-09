using System;
using System.Linq.Expressions;
using Morts.SpecificationPattern.Extensions;

namespace Morts.SpecificationPattern
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class OrSpecification<T> : Specification<T>
	{
		private readonly Specification<T> _left;
		private readonly Specification<T> _right;

		internal OrSpecification(Specification<T> left, Specification<T> right)
		{
			_left = left;
			_right = right;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected internal override Expression<Func<T, bool>> CreateExpression()
		{
			var leftExpression = _left.CreateExpression();
			var rightExpression = _right.CreateExpression();
			
			return Expression.OrElse(leftExpression.Body, rightExpression.Body).ToLambda<T>();
		}
	}
}
