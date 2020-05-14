using System;

namespace NacHelpers.Implementation
{
	/// <summary>
	/// 破棄されたことを確認できる IDisposable.
	/// </summary>
	public class BooleanDisposable : IDisposable
	{
		/// <summary>
		/// このリソースが破棄されたかどうかの真偽値を取得します。
		/// </summary>
		public bool IsDisposed { get; private set; } = false;

		public void Dispose()
		{
			IsDisposed = true;
		}
	}
}
