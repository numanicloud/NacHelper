using System;

namespace NacHelpers.FilePath2
{
	readonly struct FileExtension
	{
		public string WithDot { get; }
		public string WithoutDot => WithDot[1..];

		public FileExtension(string withDot)
		{
			if (!withDot.StartsWith("."))
			{
				throw new ArgumentOutOfRangeException(nameof(withDot), withDot, "withDot");
			}

			WithDot = withDot;
		}
	}
}
