using NacHelpers.FilePath2.Routing;

namespace NacHelpers.FilePath2.Interfaces
{
	interface IRelativeFilePath : IFilePath, IRelativePath
	{
	}

	interface IAbsoluteFilePath : IFilePath, IAbsolutePath
	{
	}

	interface IRelativeFilePathExt : IFilePathWithExtension, IRelativePath
	{
	}

	interface IAbsoluteFilePathExt : IFilePathWithExtension, IAbsolutePath
	{
	}

	interface IRelativeDirectoryPath : IDirectoryPath, IRelativePath
	{
	}

	interface IAbsoluteDirectoryPath : IDirectoryPath, IAbsolutePath
	{
	}
}
