using System;
using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct AbsoluteFilePath : IAbsolutePath, IFilePathWithExtension
	{
		private readonly string pathString;

		public AbsoluteFilePath(string pathString) : this()
		{
			if (!Path.IsPathRooted(pathString))
			{
				throw new ArgumentException("絶対パスを指定してください。", nameof(pathString));
			}

			this.pathString = pathString;
		}

		public string ToStringRepresentation() => pathString;
		public override string ToString() => ToStringRepresentation();

		public IFilePathWithoutExtension WithoutExtension()
		{
			var fileName = Path.GetFileNameWithoutExtension(pathString);
			var dirPath = Path.GetDirectoryName(pathString);
			return new AbsoluteFilePathWithoutExtension(Path.Combine(dirPath, fileName));
		}

		public AbsoluteFilePath ToAbsoluteFilePath() => this;
		public AbsoluteDirectoryPath GetParentAbsoluteDirectoryPath()
		{
			var dirPath = Path.GetDirectoryName(pathString);
			return new AbsoluteDirectoryPath(dirPath);
		}
	}
}
