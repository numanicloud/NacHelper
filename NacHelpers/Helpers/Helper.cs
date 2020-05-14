using System;
using System.Collections;
using System.Collections.Generic;

namespace NacHelpers.Helpers
{
	public static class Helper
	{
		/// <summary>
		/// 値を指定した最小値と最大値で丸めます。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="value">対象となる値。</param>
		/// <param name="min">この値を下回っていれば、この値に修正されます。</param>
		/// <param name="max">この値を上回っていれば、この値に修正されます。</param>
		/// <returns></returns>
		public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
		{
			if (value.CompareTo(max) > 0)
			{
				return max;
			}
			if (value.CompareTo(min) < 0)
			{
				return min;
			}
			return value;
		}

		public static bool IsNear(float x, float y, float error = (float)1e-12)
		{
			return Math.Abs(x - y) < error;
		}

		public static bool IsNear(double x, double y, double error = 1e-12)
		{
			return Math.Abs(x - y) < error;
		}
	}
}
