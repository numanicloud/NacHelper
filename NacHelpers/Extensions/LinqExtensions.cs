using System;
using System.Collections.Generic;
using System.Linq;

namespace NacHelpers.Extensions
{
	public static class LinqExtensions
	{
		/// <summary>
		/// コレクションの各要素に対して、
		/// それを射影したものが指定した配列に含まれているような要素を抽出します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <typeparam name="U">射影した値の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <param name="selector">コレクションの要素を射影するデリゲート。</param>
		/// <param name="values">ホワイトリストによるフィルターとなる配列。</param>
		/// <returns></returns>
		public static IEnumerable<T> Filter<T, U>(this IEnumerable<T> source,
			Func<T, U> selector,
			params U[] values)
			where U : IEquatable<U>
		{
			foreach (var item in source)
			{
				if (values.Any(x => x.Equals(selector(item))))
				{
					yield return item;
				}
			}
		}

		/// <summary>
		/// コレクションの各要素から、それを射影した値が最大となるものを返します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <typeparam name="U">射影した値の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <param name="selector">コレクションの要素を射影するデリゲート。</param>
		/// <returns></returns>
		public static T MaxItem<T, U>(this IEnumerable<T> source, Func<T, U> selector) where U : IComparable<U>
		{
			if (!source.Any())
			{
				return default;
			}

			T maxItem = source.First();
			U max = selector(maxItem);
			foreach (var item in source.Skip(1))
			{
				var work = selector(item);
				if (max.CompareTo(work) < 0)
				{
					max = work;
					maxItem = item;
				}
			}

			return maxItem;
		}

		/// <summary>
		/// 条件をはじめて満たす位置に新しい要素を挿入します。条件を満たす位置がない場合は末尾に追加します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="list">追加する先のリスト。</param>
		/// <param name="item">追加する要素。</param>
		/// <param name="condition">追加する条件。</param>
		public static void InsertAtCondition<T>(this IList<T> list, T item, Predicate<T> condition)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (condition(list[i]))
				{
					list.Insert(i, item);
					return;
				}
			}
			list.Add(item);
		}

		/// <summary>
		/// 単一の値を、それ1つだけを含む配列に変換します。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="item">配列に含む値。</param>
		/// <returns></returns>
		public static T[] ToArray<T>(this T item)
		{
			return new T[] { item };
		}

		/// <summary>
		/// コレクションの中で最大の値を持つ要素のインデックスを返します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <remarks>コレクションの要素が0個の場合、 -1 を返します。</remarks>
		/// <returns></returns>
		public static int MaxIndex<T>(this IEnumerable<T> source)
			where T : IComparable<T>
		{
			int index = 0;
			int maxIndex = -1;
			T maxItem = default;
			foreach (var item in source)
			{
				if (maxIndex == -1 || item.CompareTo(maxItem) > 0)
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
		/// コレクションの末尾に値を追加したコレクションを返します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="source">対象となるコレクション。</param>
		/// <param name="value">追加する値。</param>
		/// <returns></returns>
		public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T value)
		{
			foreach (var item in source)
			{
				yield return item;
			}
			yield return value;
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

		/// <summary>
		/// 2つのコレクションの直積を計算し、結果を指定した方法で射影した新しいコレクションを返します。
		/// </summary>
		/// <typeparam name="TOuter">1つめのコレクションの要素の型。</typeparam>
		/// <typeparam name="TInner">2つめのコレクションの要素の型。</typeparam>
		/// <typeparam name="TResult">結果のコレクションの要素の型。</typeparam>
		/// <param name="outer">1つめのコレクション。</param>
		/// <param name="inner">2つめのコレクション。</param>
		/// <param name="selector">要素を射影するデリゲート。</param>
		/// <returns></returns>
		public static IEnumerable<TResult> Product<TOuter, TInner, TResult>(
			this IEnumerable<TOuter> outer,
			IEnumerable<TInner> inner,
			Func<TOuter, TInner, TResult> selector)
		{
			return outer.Join(inner, o => 0, i => 0, selector);
		}

		/// <summary>
		/// 2つのコレクションの直積として、タプルを要素に持つコレクションを返します。
		/// </summary>
		/// <typeparam name="TOuter">1つめのコレクションの要素の型。</typeparam>
		/// <typeparam name="TInner">2つめのコレクションの要素の型。</typeparam>
		/// <param name="outer">1つめのコレクション。</param>
		/// <param name="inner">2つめのコレクション。</param>
		/// <returns></returns>
		public static IEnumerable<(TOuter outer, TInner inner)> Product<TOuter, TInner>(
			this IEnumerable<TOuter> outer,
			IEnumerable<TInner> inner)
		{
			return outer.Join(inner, o => 0, i => 0, (o, i) => (o, i));
		}
	}
}
