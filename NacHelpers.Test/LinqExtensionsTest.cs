using NacHelpers.Extensions;
using System;
using System.Linq;
using Xunit;

namespace NacHelpers.Test
{
	public class LinqExtensionsTest
	{
		[Fact]
		public void Filter()
		{
			var list1 = new[] { "Hoge", "Fuga", "Piyo", "Fire" };
			var list2 = new[] { "F", "W", "P", "B" };

			var actual = Enumerable.ToArray(list1.Filter(x => x[0].ToString(), list2));
			var expected = new[] { "Fuga", "Piyo", "Fire" };

			Assert.Equal(expected, actual);
		}
	}
}
