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
		public static T GetRandomElement<T>(this T[] source, Random random = null)
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
	}
}
