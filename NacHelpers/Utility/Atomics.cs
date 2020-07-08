using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NacHelpers.Utility
{
	public class Atomics
	{
		private readonly object lockObject;

		public Atomics(object? lockObject = null)
		{
			this.lockObject = lockObject ?? new object();
		}

		public async Task Run(Action action)
		{
			await Run(() =>
			{
				action();
				return 0;
			});
		}

		public async Task<T> Run<T>(Func<T> func)
		{
			return await Task.Run(() =>
			{
				lock (lockObject)
				{
					return func();
				}
			});
		}
	}
}
