using System;
using System.Collections.Generic;
using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct AbsoluteDirectoryPath : IAbsolutePath, IDirectoryPath
	{
		private readonly string pathString;

		public AbsoluteDirectoryPath(string pathString)
		{
			if (!Path.IsPathRooted(pathString))
			{
				throw new ArgumentException("絶対パスを指定してください。", nameof(pathString));
			}

			this.pathString = pathString;
		}

		public string ToStringRepresentation() => pathString;
		public override string ToString() => ToStringRepresentation();

		public IEnumerable<IFilePathWithExtension> EnumerateFile()
		{
			foreach (var file in Directory.EnumerateFiles(pathString))
			{
				yield return new AbsoluteFilePath(file);
			}
		}

		public AbsoluteDirectoryPath GetParentAbsoluteDirectoryPath()
		{
			var dirPath = Path.GetDirectoryName(pathString);
			return new AbsoluteDirectoryPath(dirPath);
		}
	}
}
