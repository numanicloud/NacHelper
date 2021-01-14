using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2.Routing
{
	class AbsoluteRoute : IRouting
	{
		IFilePath IRouting.GetFilePath(string pathString)
		{
			return new AbsoluteFilePath(pathString);
		}

		IFilePathWithExtension IRouting.GetFilePathWithExtension(string pathString, FileExtension extension)
		{
			return new AbsoluteFilePathExt(pathString, extension);
		}

		IDirectoryPath IRouting.GetDirectoryPath(string pathString)
		{
			return new AbsoluteDirectoryPath(pathString);
		}
	}
}
