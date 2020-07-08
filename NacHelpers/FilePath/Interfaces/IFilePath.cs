using System.IO;

namespace NacHelpers.FilePath.Interfaces
{
	public interface IFilePath : IFileSystemPath
	{
		string GetFileName() => Path.GetFileName(ToStringRepresentation());
	}
}
