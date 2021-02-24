using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NacHelpers.Extensions
{
	public static class TupleExtensions
	{
		public static T[] ToArray<T>(this (T, T) tuple)
		{
			return new T[] { tuple.Item1, tuple.Item2 };
		}

		public static (T, T)? Take2<T>(this T[] source)
		{
			if (source.Length < 2)
			{
				return null;
			}

			return (source[0], source[1]);
		}

		public static (TR, TR) Map<T, TR>(this (T, T) tuple, Func<T, TR> selector)
		{
			return (selector(tuple.Item1), selector(tuple.Item2));
		}

		public static (TR, TR, TR) Map<T, TR>(this (T, T, T) tuple, Func<T, TR> selector)
		{
			var (x, y, z) = tuple;
			return (x, y).Map(selector).Extend(selector(z));
		}

		public static (T, T) Pair<T>(this T value, T extra)
		{
			return (value, extra);
		}

		public static (T, T, T) Extend<T>(this (T, T) tuple, T extra)
		{
			var (a, b) = tuple;
			return (a, b, extra);
		}

		public static (T, T, T, T) Extend<T>(this (T, T, T) tuple, T extra)
		{
			var (a, b, c) = tuple;
			return (a, b, c, extra);
		}

	}
}
