namespace Morts.SpecificationPattern.Tests.Helpers
{
	public class TestClass
	{
		public int Id { get; }
		public int OtherId { get; }

		/// <inheritdoc />
		public TestClass(int id, int otherId)
		{
			Id = id;
			OtherId = otherId;
		}
	}
}
