using NacHelpers.Helpers;
using NacHelpers.Utility;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NacHelpers.Try
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var random = new Random();
			var atom = new AtomicConsole();

			var tasks = Enumerable.Range(0, 20)
				.Select(i => RunAsync(i, random, atom));

			await Task.WhenAll(tasks);

			Console.WriteLine("Finished!");
		}

		private static async Task RunAsync(int index, Random random, AtomicConsole atom)
		{
			var delay = random.Next() % 1000;
			var cmd = random.Next() % 10;

			await Task.Delay(delay);

			if (cmd <= 5)
			{
				await atom.WriteLineAsync($"Write from {index}");
			}
			else
			{
				await atom.Run(() =>
				{
					Console.Write("> ");
					Console.ReadLine();
				});
			}
		}
	}
}
