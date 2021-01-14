using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2.Routing
{
	public interface IRouting
	{
		IFilePath GetFilePath(string pathString);
		IFilePathWithExtension GetFilePathWithExtension(string pathString, FileExtension extension);
		IDirectoryPath GetDirectoryPath(string pathString);
	}
}
