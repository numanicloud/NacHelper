using System.Collections.Generic;
using System.Linq;

namespace NacHelpers.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// 整数値を文字列に変換します。正の数の場合も符号を与えます。
		/// </summary>
		/// <param name="value">文字列化する整数値。</param>
		/// <returns></returns>
		public static string ToSignedString(this int value)
		{
			return (value > 0 ? "+" : "") + value;
		}

		public static string Concat(IEnumerable<char> source)
		{
			return string.Concat(source);
		}

		public static string Join(this IEnumerable<string> source, string delimiter)
		{
			return string.Join(delimiter, source);
		}

		public static string Indent(this string source, int level)
		{
			var indent = Enumerable.Repeat("\t", level).Join("");
			return source.Split('\n')
				.Select(x => indent + x)
				.Join("\n");
		}
	}
}
