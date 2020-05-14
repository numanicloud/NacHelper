using System;

namespace NacHelpers.Helpers
{
	static class ConsoleHelper
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
	}
}
