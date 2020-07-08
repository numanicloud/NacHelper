using System.Collections.Generic;
using System.IO;

namespace NacHelpers.FilePath.Interfaces
{
	public interface IDirectoryPath : IFileSystemPath
	{
		bool Exists() => Directory.Exists(ToStringRepresentation());
		DirectoryInfo Create() => Directory.CreateDirectory(ToStringRepresentation());
		IEnumerable<IFilePathWithExtension> EnumerateFile();
	}
}
