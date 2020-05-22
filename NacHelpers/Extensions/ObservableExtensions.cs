using NacHelpers.Implementation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace NacHelpers.Extensions
{
    public static class ObservableExtensions
	{
		/// <summary>
		/// ストリームに過去に流れてきた値を全て合計して、後続に流します。
		/// </summary>
		/// <param name="source">ストリーム。</param>
		/// <returns></returns>
		public static IObservable<float> TotalFloat(this IObservable<float> source)
		{
			return new TotalObservable(source);
		}

        /// <summary>
        /// 指定した ObservableCollection と同期し、その要素を射影した値を常に持つ ObservableCollection を生成します。
        /// 要素の同期を停止するための IDisposable も返します。
        /// </summary>
        /// <typeparam name="T">元となるコレクションの要素の型。</typeparam>
        /// <typeparam name="U">射影後の要素の型。</typeparam>
        /// <param name="source">元となるコレクション。</param>
        /// <param name="converter">射影するためのデリゲート。</param>
        /// <returns></returns>
        public static (ObservableCollection<U> result, IDisposable disposable) ToObservableCollection<T, U>(
            this ObservableCollection<T> source,
            Func<T, U> converter)
        {
            var proxy = new ObservableCollection<U>();
            var disposable = new EventHandlingDisposable(
                () => source.CollectionChanged += Source_CollectionChanged,
                () => source.CollectionChanged -= Source_CollectionChanged);

            return (proxy, disposable);

            void Source_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    for (int i = e.NewStartingIndex; i < e.NewItems.Count; i++)
                    {
                        var value = converter((T)e.NewItems[i]);
                        proxy.Insert(e.NewStartingIndex, value);
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    proxy.Move(e.OldStartingIndex, e.NewStartingIndex);
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    for (int i = e.OldStartingIndex; i < e.OldItems.Count; i++)
                    {
                        proxy.RemoveAt(i);
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    proxy[e.NewStartingIndex] = converter(e.NewItems.Cast<T>().First());
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    proxy.Clear();
                    break;

                default:
                    break;
                }
            }
        }

        public static IObservable<T> FilterNullRef<T>(this IObservable<T?> source) where T : class
        {
            return source.Where(x => !(x is null))
                .Select(x =>
                {
                    if (x is null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return x;
                    }
                });
        }

        public static IObservable<T> FilterNullValue<T>(this IObservable<T?> source) where T : struct
        {
            return source.Where(x => !(x is null))
                .Select(x =>
                {
                    if (x is null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return x.Value;
                    }
                });
        }
    }
}
