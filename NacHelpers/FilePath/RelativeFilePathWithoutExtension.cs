using System;
using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct RelativeFilePathWithoutExtension : IRelativePath, IFilePathWithoutExtension
	{
		private readonly string pathString;

		public RelativeFilePathWithoutExtension(string pathString) : this()
		{
			this.pathString = pathString;
		}

		public string ToStringRepresentation() => pathString;
		public override string ToString() => ToStringRepresentation();

		public IDirectoryPath GetParentDirectoryPath()
		{
			var dirPath = Path.GetDirectoryName(pathString);
			return new RelativeDirectoryPath(dirPath);
		}

		public IFilePathWithExtension WithExtension(string extensionWithoutDot)
		{
			return new RelativeFilePath(pathString + "." + extensionWithoutDot);
		}

		public IAbsolutePath ToAbsolutePath()
		{
			return new AbsoluteFilePathWithoutExtension(Path.GetFullPath(pathString));
		}

		public IAbsolutePath PrependPath(IDirectoryPath basePath)
		{
			var fullPath = Path.Combine(basePath.ToStringRepresentation(), pathString);
			return new AbsoluteFilePathWithoutExtension(fullPath);
		}
	}
}
