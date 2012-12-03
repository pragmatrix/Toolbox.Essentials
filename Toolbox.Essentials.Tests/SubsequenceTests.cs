using NUnit.Framework;

namespace Toolbox.Essentials.Tests
{
	[TestFixture]
	public class SubsequenceTests
	{
		[Test]
		public void subsequenceTests()
		{
			var src = new[] {1, 2, 3, 4};
			var search = new[] {2, 3};

			var r = src.findSubsequenceIndex(search);
			Assert.That(r, Is.EqualTo(1));
		}

		[Test]
		public void subsequenceSimilarBeginning()
		{
			var src = new[] { 1, 2, 2, 3, 4 };
			var search = new[] { 2, 3 };

			var r = src.findSubsequenceIndex(search);
			Assert.That(r, Is.EqualTo(2));
		}

		[Test]
		public void exactEnd()
		{
			var src = new[] { 1, 2, 2, 3, 4 };
			var search = new[] { 3, 4 };

			var r = src.findSubsequenceIndex(search);
			Assert.That(r, Is.EqualTo(3));
		}

		[Test]
		public void atTheBeginning()
		{
			var src = new[] { 1, 2, 2, 3, 4 };
			var search = new[] { 1, 2 };

			var r = src.findSubsequenceIndex(search);
			Assert.That(r, Is.EqualTo(0));
		}

		[Test]
		public void notFound()
		{
			var src = new[] { 1, 2, 2, 3, 4 };
			var search = new[] { 3, 2 };

			var r = src.findSubsequenceIndex(search);
			Assert.That(r, Is.EqualTo(null));
		}
	}
}
