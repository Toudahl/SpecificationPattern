using System;
using System.Linq.Expressions;

namespace Morts.SpecificationPattern.Tests.Helpers
{
	class TestOtherIdSpecification : Specification<TestClass>
	{
		private readonly int _otherId;

		public TestOtherIdSpecification(int otherId)
		{
			_otherId = otherId;
		}
		/// <inheritdoc />
		protected internal override Expression<Func<TestClass, bool>> CreateExpression()
		{
			return testClass => testClass.OtherId.Equals(_otherId);
		}
	}
}
