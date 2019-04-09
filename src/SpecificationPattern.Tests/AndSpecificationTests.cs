using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Morts.SpecificationPattern.Tests.Helpers;
using Xunit;

namespace Morts.SpecificationPattern.Tests
{
	public class AndSpecificationTests
	{
		[Fact]
		[Trait("Category", "Unit")]
		public void And_TwoDifferentPropsShouldMatch_MatchFound()
		{
			//ARRANGE
			var expectedId = 1;
			var expectedOtherId = 1;
			var expected = new TestClass(expectedId, expectedOtherId);
			var list = new List<TestClass>
			{
				expected,
				new TestClass(1,2),
				new TestClass(1,3),
				new TestClass(1,4),
				new TestClass(1,5),
			};

			var idSpec = new TestIdSpecification(expectedId);
			var otherIdSpec = new TestOtherIdSpecification(expectedOtherId);
			var andSpec = idSpec.And(otherIdSpec);


			//ACT
			var result = list.Where(andSpec);

			//ASSERT
			result.Single().Should().BeSameAs(expected);
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void And_TwoDifferentPropsShouldMatch_NoMatchFound()
		{
			//ARRANGE
			var list = new List<TestClass>
			{
				new TestClass(1,1),
				new TestClass(1,2),
				new TestClass(1,3),
				new TestClass(1,4),
				new TestClass(1,5),
			};

			var idSpec = new TestIdSpecification(0);
			var otherIdSpec = new TestOtherIdSpecification(0);
			var andSpec = idSpec.And(otherIdSpec);


			//ACT
			var result = list.Where(andSpec);

			//ASSERT
			result.Should().BeEmpty();
		}

	}
}
