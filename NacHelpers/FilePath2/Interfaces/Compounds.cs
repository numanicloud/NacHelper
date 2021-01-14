using NacHelpers.FilePath2.Routing;

namespace NacHelpers.FilePath2.Interfaces
{
	public interface IRelativeFilePath : IFilePath, IRelativePath
	{
	}

	public interface IAbsoluteFilePath : IFilePath, IAbsolutePath
	{
	}

	public interface IRelativeFilePathExt : IFilePathWithExtension, IRelativePath
	{
	}

	public interface IAbsoluteFilePathExt : IFilePathWithExtension, IAbsolutePath
	{
	}

	public interface IRelativeDirectoryPath : IDirectoryPath, IRelativePath
	{
	}

	public interface IAbsoluteDirectoryPath : IDirectoryPath, IAbsolutePath
	{
	}
}
