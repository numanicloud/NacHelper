using System.Collections.Generic;
using System.IO;
using System.Linq;
using NacHelpers.FilePath2.Routing;

namespace NacHelpers.FilePath2.Interfaces
{
	interface IDirectoryPath : IFileSystemPath
	{
		public bool Exists() => Directory.Exists(PathString);
		public DirectoryInfo Create() => Directory.CreateDirectory(PathString);
		public DirectoryInfo GetInfo() => new DirectoryInfo(PathString);

		public IEnumerable<IFilePath> EnumerateFiles()
		{
			return Directory.EnumerateFiles(PathString)
				.Select(path => PathHelpers.AsFilePath(path, RoutingInfo));
		}

		public IFilePath CombineFile<T>(T file) where T : IFilePath, IRelativePath
		{
			return RoutingInfo.GetFilePath(Path.Combine(PathString, file.PathString));
		}

		public IDirectoryPath CombineDirectory<T>(T dir2) where T : IDirectoryPath, IRelativePath
		{
			return RoutingInfo.GetDirectoryPath(Path.Combine(PathString, dir2.PathString));
		}
	}
}
