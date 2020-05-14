using System;

namespace NacHelpers.Implementation
{
	/// <summary>
	/// 生成時と破棄時にデリゲートを実行する IDispoable.
	/// </summary>
	public sealed class EventHandlingDisposable : IDisposable
	{
		private readonly Action onExit;

		/// <summary>
		/// EventHandlingDisposable の新しいインスタンスを生成します。
		/// </summary>
		/// <param name="onEnter">生成時に実行するデリゲート。</param>
		/// <param name="onExit">破棄時に実行するデリゲート。</param>
		public EventHandlingDisposable(Action onEnter, Action onExit)
		{
			onEnter?.Invoke();
			this.onExit = onExit;
		}

		public void Dispose()
		{
			onExit?.Invoke();
		}
	}
}
