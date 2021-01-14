using NacHelpers.Implementation;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NacHelpers.Utility
{
	public abstract class AtomicOps<T> : IDisposable
		where T : AtomicOps<T>, new()
	{
		private static int NextId = 0;
		public int Id { get; set; } = NextId++;

		protected class Lock
		{
			private static int NextId = 0;

			public int Count { get; set; } = 0;
			public int Id { get; set; } = NextId++;
		}

		private EventHandlingDisposable? disposable;
		private List<T> children = new List<T>();

		protected Lock LockObject { get; } = new Lock();

		public void Dispose()
		{
			Console.WriteLine($"dispose. disposable = {disposable}");
			disposable?.Dispose();
		}

		public T CreateAtomicScope()
		{
			bool taken = false;
			try
			{
				Monitor.Enter(LockObject, ref taken);

				if (taken)
				{
					LockObject.Count++;
				}

				var child = new T();
				children.Add(child);
				child.disposable = new EventHandlingDisposable(
					() => { },
					() =>
					{
						if (taken)
						{
							LockObject.Count--;
							Monitor.Exit(LockObject);
						}
						children.Remove(child);
					});
				return child;

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (taken)
				{
					Monitor.Exit(LockObject);
				}
			}
		}
	}
}
