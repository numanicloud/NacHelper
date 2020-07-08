using System;
using System.IO;
using System.Reactive.Subjects;

namespace NacHelpers.Utility
{
	public class UnHandledExceptionHandler
	{
		private readonly Subject<Exception> onErorProcessedSubject = new Subject<Exception>();

		public string ErrorOutputPath { get; set; } = "./";
		public IObservable<Exception> OnErrorProcessed => onErorProcessedSubject;

		public void ProcessError(Exception exception)
		{
#if DEBUG
			throw exception;
#else
			if (exception is AggregateException aggregated)
			{
				ProcessError(aggregated, (stream, e) =>
				{
					WriteException(stream, aggregated);
					foreach (var inner in aggregated.InnerExceptions)
					{
						stream.WriteLine();
						WriteException(stream, inner);
					}
				});
			}
			else
			{
				ProcessError(exception, (stream, e) => WriteException(stream, e));
			}
			onErorProcessedSubject.OnNext(exception);
#endif
		}

		private void ProcessError<TException>(TException ex, Action<StreamWriter, TException> write)
			where TException : Exception
		{
			var footer = DateTime.Now.ToString("yyyyMMdd_HHmm");
			var fileName = $"../error{footer}.txt";
			using (var log = new StreamWriter(fileName))
			{
				write(log, ex);
				log.WriteLine();
			}
		}

		private static void WriteException(StreamWriter log, Exception ex)
		{
			log.WriteLine(ex.GetType().Name);
			log.WriteLine(ex.Message);
			log.WriteLine(ex.StackTrace);
		}
	}
}
