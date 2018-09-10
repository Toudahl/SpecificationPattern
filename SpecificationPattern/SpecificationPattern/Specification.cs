using System;
using System.Linq.Expressions;

namespace Morts.SpecificationPattern
{
	/// <summary>
	/// Implementing this class allows you to flexibly query various types of lists, using linq
	/// <para>
	/// Contains implicit operators that converts to funcs and expressions
	/// </para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Specification<T>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected internal abstract Expression<Func<T, bool>> CreateExpression();

		/// <summary>
		/// This specification and the other specification must evaluate to an expression that returns true when the resulting predicate is evaluated.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Specification<T> And(Specification<T> other) => new AndSpecification<T>(this, other);

		/// <summary>
		/// This specification or the other specification must evaluate to an expression that returns true when the resulting predicate is evaluated.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Specification<T> Or(Specification<T> other) => new OrSpecification<T>(this, other);

		/// <summary>
		/// This specification, not the other specification must evaluate to an expression that returns true when the resulting predicate is evaluated.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Specification<T> Not(Specification<T> other) => new NotSpecification<T>(this, other);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spec"></param>
		public static implicit operator Expression<Func<T, bool>>(Specification<T> spec) => spec.CreateExpression();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spec"></param>
		public static implicit operator Func<T, bool>(Specification<T> spec) => spec.CreateExpression().Compile();
	}
}
