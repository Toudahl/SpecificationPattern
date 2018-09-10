using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Morts.SpecificationPattern.Tests.Helpers;
using Xunit;

namespace Morts.SpecificationPattern.Tests
{
	public class SpecificationTests
	{
		[Fact]
		[Trait("Category", "Unit")]
		public void SingleSpecification_FindById_ShouldFindSingleResult()
		{
			//ARRANGE
			var expected = new TestClass(1, 1);
			var list = new List<TestClass>
			{
				expected,
				new TestClass(2,1),
				new TestClass(3,1),
				new TestClass(4,1),
				new TestClass(5,1),
			};
			var idSpec = new TestIdSpecification(1);
			//ACT

			var result = list.Where(idSpec);

			//ASSERT
			result.Single().Should().BeSameAs(expected);
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void SingleSpecification_FindById_ShouldNotFindAnything()
		{
			//ARRANGE
			var list = new List<TestClass>
			{
				new TestClass(1, 1),
				new TestClass(2,1),
				new TestClass(3,1),
				new TestClass(4,1),
				new TestClass(5,1),
			};
			var idSpec = new TestIdSpecification(6);
			//ACT

			var result = list.Where(idSpec);

			//ASSERT
			result.Should().BeEmpty();
		}

	}
}
