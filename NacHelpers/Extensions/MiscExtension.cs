using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NacHelpers.Extensions
{
	public static class MiscExtension
	{
		/// <summary>
		/// 配列の要素からランダムに値を選び出します。
		/// </summary>
		/// <typeparam name="T">配列の要素の型。</typeparam>
		/// <param name="source">対象となる配列。</param>
		/// <param name="random">乱数クラス。</param>
		/// <returns></returns>
		public static T GetRandomElement<T>(this T[] source, Random? random = null)
		{
			random = random ?? new Random();
			var index = random.Next() % source.Length;
			return source[index];
		}

		/// <summary>
		/// 非同期処理を待機しないことを表明します。
		/// </summary>
		/// <param name="task">対象となる非同期処理。</param>
		public static async void Forget(this Task task)
		{
			await task;
		}

		/// <summary>
		/// 指定した IDisposable を、コレクションに追加します。
		/// </summary>
		/// <param name="disposable"></param>
		/// <param name="collection"></param>
		/// <returns></returns>
		public static IDisposable AddTo(this IDisposable disposable, ICollection<IDisposable> collection)
		{
			collection.Add(disposable);
			return disposable;
		}

		public static bool AllEqual<T>(this T left, T right, params Func<T, object>[] selectors)
		{
			foreach (var selector in selectors)
			{
				if (selector(left) != selector(right))
				{
					return false;
				}
			}

			return true;
		}

		public static void AddRangeTo<T>(this IEnumerable<T> source, List<T> list)
		{
			list.AddRange(source);
		}
	}
}
