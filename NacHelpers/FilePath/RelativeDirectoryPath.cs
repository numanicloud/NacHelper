using System;
using System.Collections.Generic;
using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct RelativeDirectoryPath : IDirectoryPath, IRelativePath
	{
		private readonly string pathString;

		public RelativeDirectoryPath(string pathString)
		{
			this.pathString = pathString;
		}

		public string ToStringRepresentation() => pathString;
		public override string ToString() => ToStringRepresentation();

		public IDirectoryPath GetParentDirectoryPath()
		{
			return new RelativeDirectoryPath(Path.GetDirectoryName(pathString));
		}

		public IAbsolutePath ToAbsolutePath()
		{
			var fullPath = Path.GetFullPath(pathString);
			return new AbsoluteDirectoryPath(fullPath);
		}

		public IAbsolutePath PrependPath(IDirectoryPath basePath)
		{
			var fullPath = Path.Combine(basePath.ToStringRepresentation(), pathString);
			return new AbsoluteDirectoryPath(fullPath);
		}

		public IEnumerable<IFilePathWithExtension> EnumerateFile()
		{
			foreach (var file in Directory.EnumerateFiles(pathString))
			{
				yield return new RelativeFilePath(file);
			}
		}
	}
}
