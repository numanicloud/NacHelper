using System;
using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct AbsoluteFilePathWithoutExtension : IAbsolutePath, IFilePathWithoutExtension
	{
		private readonly string pathString;

		public AbsoluteFilePathWithoutExtension(string pathString) : this()
		{
			if (!Path.IsPathRooted(pathString))
			{
				throw new ArgumentException("絶対パスを指定してください。", nameof(pathString));
			}

			this.pathString = pathString;
		}

		public string ToStringRepresentation() => pathString;
		public IFilePathWithExtension WithExtension(string extensionWithoutDot)
		{
			return new AbsoluteFilePath(pathString + "." + extensionWithoutDot);
		}

		public AbsoluteDirectoryPath GetParentAbsoluteDirectoryPath()
		{
			var dirPath = Path.GetDirectoryName(pathString);
			return new AbsoluteDirectoryPath(dirPath);
		}
	}
}
