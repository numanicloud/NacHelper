using System;

namespace NacHelpers.Helpers
{
	public static class ConsoleHelper
	{
		public static void WriteLine(string message, ConsoleColor color)
		{
			var source = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ForegroundColor = source;
		}

		public static void Write(string message, ConsoleColor color)
		{
			var source = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.Write(message);
			Console.ForegroundColor = source;
		}

		public static T ReadLine<T>(Predicate<string> isValid, Func<string, T> toString)
		{
			while (true)
			{
				Console.Write("> ");

				var line = Console.ReadLine();
				if (isValid(line))
				{
					return toString(line);
				}
			}
		}
	}
}
