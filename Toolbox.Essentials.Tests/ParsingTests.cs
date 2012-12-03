using NUnit.Framework;
using Toolbox.Parsing;

namespace Toolbox.Essentials.Tests
{
	[TestFixture]
	public class ParsingTests
	{
		[Test]
		public void simpleParse()
		{
			var res = "Name:Value".tryParse(@"(?<name>\w+):(?<value>\w+)");
			Assert.That(res.name, Is.EqualTo("Name"));
			Assert.That(res.value, Is.EqualTo("Value"));
		}

		[Test]
		public void optionalParse()
		{
			var res = "Name:".tryParse(@"(?<name>\w+):(?<value>\w+)?");
			Assert.That(res.name, Is.EqualTo("Name"));
			Assert.True(res.value == null);
		}

		[Test]
		public void failed()
		{
			var res = "Name:".tryParse(@"(?<name>\w+):(?<value>\w+)");
			Assert.IsNull(res);
		}

		[Test]
		public void excessCharacters()
		{
			var res = "Name::".tryParse(@"(?<name>\w+):");
			Assert.IsNull(res);
		}

		[Test]
		public void containment()
		{
			{
				var res = "XX:Hello".tryParse(@"(?<name>\w+):(?<container>(?<word>\w+)|20)");
				Assert.That(res.name, Is.EqualTo("XX"));
				Assert.That(res.container, Is.EqualTo("Hello"));
				Assert.That(res.word, Is.EqualTo("Hello"));
			}

			{
				var res = "XX:::".tryParse(@"(?<name>\w+):(?<container>((?<word>\w+)|(::)))");
				Assert.That(res.name, Is.EqualTo("XX"));
				Assert.That(res.container, Is.EqualTo("::"));
				Assert.IsNull(res.word);
			}
		}
	}
}
