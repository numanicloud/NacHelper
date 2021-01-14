using System.IO;
using NacHelpers.FilePath2.Interfaces;
using NacHelpers.FilePath2.Routing;

namespace NacHelpers.FilePath2
{
	static class PathHelpers
	{
		public static IFilePath AsFilePath(string pathString)
		{
			IRouting routing = Path.IsPathRooted(pathString)
				? new AbsoluteRoute()
				: new RelativeRoute();

			return AsFilePath(pathString, routing);
		}

		public static IFilePath AsFilePath(string pathString, IRouting routing)
		{
			if (Path.EndsInDirectorySeparator(pathString))
			{
				pathString.TrimEnd(Path.DirectorySeparatorChar);
			}

			if (!Path.HasExtension(pathString))
			{
				return routing.GetFilePath(pathString);
			}

			var baseName = Path.GetFileNameWithoutExtension(pathString);
			var ext = new FileExtension(Path.GetExtension(pathString));
			return routing.GetFilePathWithExtension(baseName, ext);
		}

		public static IDirectoryPath AsDirectoryPath(string pathString)
		{
			IRouting routing = Path.IsPathRooted(pathString)
				? new AbsoluteRoute()
				: new RelativeRoute();

			if (!Path.EndsInDirectorySeparator(pathString))
			{
				pathString += Path.DirectorySeparatorChar;
			}

			return routing.GetDirectoryPath(pathString);
		}

		public static IFileSystemPath AsAnyPath(string pathString)
		{
			IFileSystemPath result = Path.EndsInDirectorySeparator(pathString)
				? AsDirectoryPath(pathString)
				: AsFilePath(pathString);
			return result;
		}
	}
}
