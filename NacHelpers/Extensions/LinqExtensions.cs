using System;
using System.Collections.Generic;
using System.Linq;

namespace NacHelpers.Extensions
{
	public static class LinqExtensions
	{
		/// <summary>
		/// 単一の値を、それ1つだけを含む配列に変換します。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="item">配列に含む値。</param>
		/// <returns></returns>
		public static T[] WrapByArray<T>(this T item)
		{
			return new T[] { item };
		}

		/// <summary>
		/// 単一の値を、それ1つだけを含むコレクションに変換します。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="source">コレクションに含む値。</param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumerable<T>(this T? source) where T : class
		{
			return source is null
				? Enumerable.Empty<T>()
				: new T[] { source };
		}

		public static IEnumerable<T> FilterNull<T>(this IEnumerable<T?> source) where T : notnull
		{
			foreach (var item in source)
			{
				if (item is { })
				{
					yield return item;
				}
			}
		}

		/// <summary>
		/// コレクションの中で最大の値を持つ要素のインデックスを返します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <remarks>コレクションの要素が0個の場合、 -1 を返します。</remarks>
		/// <returns></returns>
		public static int MaxIndex<T>(this IEnumerable<T> source)
			where T :  IComparable<T>
		{
			int index = 0;
			int maxIndex = -1;
			T maxItem = default;
			foreach (var item in source)
			{
				if (maxIndex == -1 || (maxItem is T t && item.CompareTo(t) > 0))
				{
					maxItem = item;
					maxIndex = index;
				}
				++index;
			}
			return maxIndex;
		}

		/// <summary>
		/// コレクションをインデックスを添えて列挙します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <returns></returns>
		public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
		{
			int index = 0;
			foreach (var item in source)
			{
				yield return (item, index);
				++index;
			}
		}
		
		/// <summary>
		/// コレクションの先頭に値を追加したコレクションを返します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <param name="value">追加する値。</param>
		/// <returns></returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T value)
		{
			yield return value;
			foreach (var item in source)
			{
				yield return value;
			}
		}

		public static IEnumerable<T> ToLinear<T>(this IEnumerable<IEnumerable<T>> source)
		{
			return source.SelectMany(x => x);
		}
	}
}
