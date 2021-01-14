using NacHelpers.Extensions;
using System;
using System.Threading.Tasks;

namespace NacHelpers.Helpers
{
	public static class AsyncConsole
	{
		private static object ioLock = new object();
		private static object readLineLock = new object();

		public static async Task<string> ReadLineAsync()
		{
			Task<string> task;
			lock (readLineLock)
			{
				task = RunLocking(() => Console.ReadLine());
			}

			LockTimer(readLineLock, 1500).Forget();

			return await task;
		}

		public static async Task WriteLine(string msg) => await RunLocking(() => Console.WriteLine(msg));

		public static async Task Write(string msg) => await RunLocking(() => Console.Write(msg));

		private static async Task LockTimer(object lockObject, int milliseconds)
		{
			await Task.Run(() =>
			{
				lock (lockObject)
				{
					Task.Delay(milliseconds).Wait();
				}
			});
		}

		private static async Task<T> RunLocking<T>(Func<T> func)
		{
			return await Task.Run(() =>
			{
				lock (ioLock)
				{
					return func();
				}
			});
		}

		private static async Task RunLocking(Action action)
		{
			await Task.Run(() =>
			{
				lock (ioLock)
				{
					action();
				}
			});
		}
	}
}
