using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Morts.SpecificationPattern.Tests.Helpers;
using Xunit;

namespace Morts.SpecificationPattern.Tests
{
	public class OrSpecificationTests
	{
		[Fact]
		[Trait("Category", "Unit")]
		public void Or_Scenario_ExpectedBehavior()
		{
			//ARRANGE
			var expectedIdOne = 1;
			var expectedIdTwo = 2;
			var expectedOne = new TestClass(expectedIdOne, 0);
			var expectedTwo = new TestClass(expectedIdTwo, 0);
			var list = new List<TestClass>
			{
				new TestClass(5,1),
				new TestClass(4,2),
				new TestClass(3,3),
				expectedTwo,
				expectedOne
			};

			var idSpecOne = new TestIdSpecification(expectedIdOne);
			var idSpecTwo = new TestIdSpecification(expectedIdTwo);
			var orSpec = idSpecOne.Or(idSpecTwo);

			//ACT
			var result = list.Where(orSpec).ToList();

			//ASSERT

			result.Should().HaveCount(2);
			result.Should().Contain(new[] {expectedOne, expectedTwo});

		}
	}
}
