using System;
using System.Linq.Expressions;

namespace Morts.SpecificationPattern.Tests.Helpers
{
	class TestIdSpecification : Specification<TestClass>
	{
		private readonly int _id;

		public TestIdSpecification(int id)
		{
			_id = id;
		}
		protected internal override Expression<Func<TestClass, bool>> CreateExpression()
		{
			return testClass => testClass.Id.Equals(_id);
		}
	}
}
