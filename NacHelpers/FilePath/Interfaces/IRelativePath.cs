namespace NacHelpers.FilePath.Interfaces
{
	public interface IRelativePath : IFileSystemPath
	{
		IAbsolutePath PrependPath(IDirectoryPath basePath);
	}
}
