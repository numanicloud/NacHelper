using System.IO;
using NacHelpers.FilePath.Interfaces;

namespace NacHelpers.FilePath
{
	public readonly struct RelativeFilePath : IRelativePath, IFilePathWithExtension
	{
		private readonly string pathString;

		public RelativeFilePath(string pathString) : this()
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

		public IAbsolutePath ToAbsolutePath() => ToAbsoluteFilePath();

		public IAbsolutePath PrependPath(IDirectoryPath basePath)
		{
			var fullPath = Path.Combine(basePath.ToStringRepresentation(), pathString);
			return new AbsoluteFilePath(fullPath);
		}

		public IFilePathWithoutExtension WithoutExtension()
		{
			var fileName = Path.GetFileNameWithoutExtension(pathString);
			var dirPath = Path.GetDirectoryName(pathString);
			return new RelativeFilePathWithoutExtension(Path.Combine(dirPath, fileName));
		}

		public AbsoluteFilePath ToAbsoluteFilePath() => new AbsoluteFilePath(Path.GetFullPath(pathString));
	}
}
