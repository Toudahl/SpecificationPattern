using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Morts.SpecificationPattern.Tests.Helpers;
using Xunit;

namespace Morts.SpecificationPattern.Tests
{
	public class NotSpecificationTests
	{
		[Fact]
		[Trait("Category", "Unit")]
		public void Not_TwoDifferentPropsOneShouldNotMatch_ShouldFindOne()
		{
			//ARRANGE
			var expectedId = 1;
			var notExpectedOtherId = 2;
			var expected = new TestClass(expectedId, 1);
			var list = new List<TestClass>
			{
				expected,
				new TestClass(1,2),
				new TestClass(1,2),
				new TestClass(1,2),
				new TestClass(1,2),
			};

			var idSpec = new TestIdSpecification(expectedId);
			var otherIdSpec = new TestOtherIdSpecification(notExpectedOtherId);
			var notSpec = idSpec.Not(otherIdSpec);


			//ACT
			var result = list.Where(notSpec);

			//ASSERT
			result.Single().Should().BeSameAs(expected);
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void Not_TwoDifferentPropsOneShouldNotMatch_ShouldNotFindAny()
		{
			//ARRANGE
			var list = new List<TestClass>
			{
				new TestClass(1, 2),
				new TestClass(1,2),
				new TestClass(1,2),
				new TestClass(1,2),
				new TestClass(1,2),
			};

			var idSpec = new TestIdSpecification(1);
			var otherIdSpec = new TestOtherIdSpecification(2);
			var notSpec = idSpec.Not(otherIdSpec);


			//ACT
			var result = list.Where(notSpec);

			//ASSERT
			result.Should().BeEmpty();
		}

	}
}
