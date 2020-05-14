using System;
using System.Linq;
using System.Reactive.Linq;

namespace NacHelpers.Implementation
{
	class TotalObservable : IObservable<float>
	{
		private IObservable<float> source;

		public TotalObservable(IObservable<float> source)
		{
			this.source = source;
		}

		public IDisposable Subscribe(IObserver<float> observer)
		{
			float total = 0;
			return source.Do(x => total += x)
				.Select(x => total)
				.Subscribe(observer);
		}
	}
}
